

using System.Threading.Tasks;
using Catalog.Domain.Common;
using Catalog.Domain.Products.Interfaces;
using EventBus.Messages.Events;
using MassTransit;

namespace Catalog.Application.EventBusConsumer
{
   public class CreateOrderConsumer : IConsumer<CreateOrderEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<CreateOrderEvent> context)
        {
            var product = await _unitOfWork.ProductRepository.GetById(context.Message.ProductId);
            product.Inventory -= context.Message.Count;
            await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Commit();
        }
    }
}
