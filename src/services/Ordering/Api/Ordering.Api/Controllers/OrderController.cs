using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

using MediatR;
using Ordering.Application.Common;
using Ordering.Application.Orders.Commands;
using Ordering.Application.Orders.Queries;
using Ordering.Application.Orders.QueryViews;

namespace Ordering.Api.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        #region GetAllOrder
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(QueryResult<IEnumerable<GetAllOrderQueryView>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<QueryResult<IEnumerable<GetAllOrderQueryView>>>> GetAllOrderQuery()
        {
            var query = new GetAllOrderQuery();
            var result = await mediator.Send(query);
            return Response(result);
        }
        #endregion

        #region CreateOrder
        [HttpPost("Create")]
        [ProducesResponseType(typeof(CommandResult),(int) HttpStatusCode.OK)]
        public async Task<ActionResult<CommandResult>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await mediator.Send(command);
            return Response(result);
        }
        #endregion
    }
}