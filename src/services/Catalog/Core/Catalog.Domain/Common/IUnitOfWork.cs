using System;
using System.Threading.Tasks;
using Catalog.Domain.Products.Interfaces;

namespace Catalog.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        Task<int> Commit();
    }
}
