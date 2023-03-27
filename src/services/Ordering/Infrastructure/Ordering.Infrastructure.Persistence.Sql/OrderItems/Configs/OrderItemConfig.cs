using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.OrderItems.Entities;
using Ordering.Infrastructure.Persistence.Sql.Common;

namespace Ordering.Infrastructure.Persistence.Sql.OrderItems.Configs
{
    public class OrderItemConfig : EntityConfig<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.Property(p => p.Price).IsRequired();

            builder.Property(p => p.Count).IsRequired();

            builder.Property(p => p.ProductId).IsRequired();

            builder.HasOne(p => p.Order)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(p => p.OrderId);

            base.Configure(builder);
        }
    }
}
