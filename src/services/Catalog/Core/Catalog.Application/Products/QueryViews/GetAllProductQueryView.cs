

using Catalog.Application.Common;

namespace Catalog.Application.Products.QueryViews
{
   public class GetAllProductQueryView:QueryView
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
    }
}
