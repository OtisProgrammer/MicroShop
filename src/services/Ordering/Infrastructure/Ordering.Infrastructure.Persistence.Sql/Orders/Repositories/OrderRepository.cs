using Ordering.Domain.Orders.Entities;
using Ordering.Domain.Orders.Interfaces;
using Ordering.Infrastructure.Persistence.Sql.Common;
using Ordering.Infrastructure.Persistence.Sql.Contexts;

namespace Ordering.Infrastructure.Persistence.Sql.Orders.Repositories
{
    public class OrderRepository:Repository<Order>,IOrderRepository
    {
        public OrderRepository(OrderDbContext context) : base(context)
        {
        }
    }
}
