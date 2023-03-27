
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Common;

namespace Ordering.Infrastructure.Persistence.Sql.Common
{
    public class EntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
            {
                builder.HasKey(p =>p.Id);

                builder.Property(p => p.CreatedDateTime).HasDefaultValueSql("getdate()").IsRequired();

                builder.Property(p => p.UpdatedDateTime).IsRequired(false);
            }
    }
}
