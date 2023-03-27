using Catalog.Domain.Products.Entities;
using Catalog.Domain.Products.Interfaces;
using Catalog.Infrastructure.Persistence.Sql.Common;
using Catalog.Infrastructure.Persistence.Sql.Contexts;

namespace Catalog.Infrastructure.Persistence.Sql.Products.Repositories
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(CatalogBbContext context) : base(context)
        {
        }
    }
}
