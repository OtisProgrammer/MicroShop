using System.Collections.Generic;
using MediatR;
using Ordering.Application.Common;

namespace Ordering.Application.Orders.Commands
{
    public class CreateOrderCommand:IRequest<CommandResult>
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public IEnumerable<CreateOrderItemsDto> Items { get; set; }
    }

    public class CreateOrderItemsDto
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
    }
}
