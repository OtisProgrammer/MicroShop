using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Orders.Entities;
using Ordering.Infrastructure.Persistence.Sql.Common;

namespace Ordering.Infrastructure.Persistence.Sql.Orders.Configs
{
    public class OrderConfig:EntityConfig<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.Property(p => p.UserId).IsRequired();

            builder.Property(p => p.Code).HasMaxLength(10).IsRequired();

            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();

            builder.Property(p => p.Address).HasMaxLength(500).IsRequired();

            base.Configure(builder);
        }
    }
}
