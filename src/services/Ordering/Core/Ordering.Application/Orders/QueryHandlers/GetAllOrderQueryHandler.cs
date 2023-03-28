
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ordering.Application.Common;
using Ordering.Application.Orders.Queries;
using Ordering.Application.Orders.QueryViews;
using Ordering.Domain.OrderItems.Interfaces;
using Ordering.Domain.Orders.Interfaces;

namespace Ordering.Application.Orders.QueryHandlers
{
    public class GetAllOrderQueryHandler:IRequestHandler<GetAllOrderQuery,QueryResult<IEnumerable<GetAllOrderQueryView>>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public GetAllOrderQueryHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<QueryResult<IEnumerable<GetAllOrderQueryView>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var queryResult = new QueryResult<IEnumerable<GetAllOrderQueryView>>();
            var result = new List<GetAllOrderQueryView>();
            var orders = await _orderRepository.GetAll();
            foreach (var order in orders)
            {
                var items = await _orderItemRepository.GetAll();
                result.Add(new GetAllOrderQueryView()
                {
                    Address = order.Address,
                    Description = order.Description,
                    Id = order.Id,
                    Items = items.Select(i=>new GetAllOrderItemsQueryView()
                    {
                        Id = i.Id,
                        Count = i.Count,
                        Price = i.Price,
                        ProductId = i.ProductId
                    }).ToList()
                });
            }
            queryResult.Data = result;
            queryResult.Message = "عملیات با موفقیت انجام شد";
            queryResult.MessageCode = (int)HttpStatusCode.OK;
            return queryResult;
        }
    }
}
