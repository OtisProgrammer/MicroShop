using Ordering.Domain.Common;
using System;
using System.Threading.Tasks;
using Ordering.Domain.OrderItems.Interfaces;
using Ordering.Domain.Orders.Interfaces;
using Ordering.Infrastructure.Persistence.Sql.Contexts;

namespace Ordering.Infrastructure.Persistence.Sql.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext _context;
        public IOrderRepository OrderRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }

        public UnitOfWork(OrderDbContext context, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _context = context;
            OrderRepository = orderRepository;
            OrderItemRepository = orderItemRepository;
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
