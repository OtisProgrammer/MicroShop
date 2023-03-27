using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

using MediatR;
using Ordering.Application.Common;
using Ordering.Application.Orders.Commands;

namespace Ordering.Api.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        //#region GetAllProduct
        //[HttpGet("GetAll")]
        //[ProducesResponseType(typeof(QueryResult<IEnumerable<GetAllProductQueryView>>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<QueryResult<IEnumerable<GetAllProductQueryView>>>> GetAllProduct()
        //{
        //    var query = new GetAllProductQuery();
        //    var result = await mediator.Send(query);
        //    return Response(result);
        //}
        //#endregion

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