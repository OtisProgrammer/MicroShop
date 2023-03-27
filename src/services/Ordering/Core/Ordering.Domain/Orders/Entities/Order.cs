using System.Collections.Generic;
using Ordering.Domain.Common;
using Ordering.Domain.OrderItems.Entities;

namespace Ordering.Domain.Orders.Entities
{
    public class Order : Entity
    {
        public long UserId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
