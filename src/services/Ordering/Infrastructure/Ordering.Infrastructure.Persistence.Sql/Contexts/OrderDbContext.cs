using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.OrderItems.Entities;
using Ordering.Domain.Orders.Entities;

namespace Ordering.Infrastructure.Persistence.Sql.Contexts
{
    public class OrderDbContext : DbContext
    {
        #region Entities
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        #endregion
        public OrderDbContext(DbContextOptions options) : base(options)
        {
             Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries().Where(p => p.State is EntityState.Added or EntityState.Modified);
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property("UpdatedDateTime").CurrentValue = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("CreatedDateTime").CurrentValue = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync();
        }
    }
}
