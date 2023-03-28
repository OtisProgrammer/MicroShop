

using System.Collections.Generic;
using Ordering.Application.Common;

namespace Ordering.Application.Orders.QueryViews
{
    public class GetAllOrderQueryView : QueryView
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public IEnumerable<GetAllOrderItemsQueryView> Items { get; set; }
    }

    public class GetAllOrderItemsQueryView : QueryView
    {
        public long ProductId { get; set; }
        public  int Price { get; set; }
        public int Count { get; set; }
    }
}
