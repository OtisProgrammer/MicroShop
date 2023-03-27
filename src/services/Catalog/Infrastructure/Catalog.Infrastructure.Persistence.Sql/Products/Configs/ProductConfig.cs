using Catalog.Domain.Products.Entities;
using Catalog.Infrastructure.Persistence.Sql.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Persistence.Sql.Products.Configs
{
    public class ProductConfig:EntityConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();

            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();

            base.Configure(builder);
        }
    }
}
