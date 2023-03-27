

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistence.Sql.Contexts
{
    public class CatalogBbContext : DbContext
    {
        #region Entities
        public DbSet<Product> Product { get; set; }
        #endregion
        public CatalogBbContext(DbContextOptions options) : base(options)
        {
            // Database.Migrate();
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
