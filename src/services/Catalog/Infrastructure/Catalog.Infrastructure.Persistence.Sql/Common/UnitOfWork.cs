

using System;
using System.Threading.Tasks;
using Catalog.Domain.Common;
using Catalog.Domain.Products.Interfaces;
using Catalog.Infrastructure.Persistence.Sql.Contexts;

namespace Catalog.Infrastructure.Persistence.Sql.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogBbContext _context;
        public IProductRepository ProductRepository { get; }

        public UnitOfWork(CatalogBbContext context, IProductRepository productRepository)
        {
            _context = context;
            ProductRepository = productRepository;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
