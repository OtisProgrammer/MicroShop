using Catalog.Domain.Common;

namespace Catalog.Domain.Products.Entities
{
    public class Product : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
    }
}
