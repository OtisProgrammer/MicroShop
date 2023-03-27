using Ordering.Domain.OrderItems.Entities;
using Ordering.Domain.OrderItems.Interfaces;
using Ordering.Infrastructure.Persistence.Sql.Common;
using Ordering.Infrastructure.Persistence.Sql.Contexts;

namespace Ordering.Infrastructure.Persistence.Sql.OrderItems.Repositories
{
    public class OrderItemRepository:Repository<OrderItem>,IOrderItemRepository
    {
        public OrderItemRepository(OrderDbContext context) : base(context)
        {
        }
    }
}
