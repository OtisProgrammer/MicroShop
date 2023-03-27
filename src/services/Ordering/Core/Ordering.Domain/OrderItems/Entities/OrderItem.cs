using Ordering.Domain.Common;
using Ordering.Domain.Orders.Entities;

namespace Ordering.Domain.OrderItems.Entities
{
    public class OrderItem:Entity
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
