using System;
using System.Threading.Tasks;
using Ordering.Domain.OrderItems.Interfaces;
using Ordering.Domain.Orders.Interfaces;

namespace Ordering.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        Task<int> Commit();
    }
}
