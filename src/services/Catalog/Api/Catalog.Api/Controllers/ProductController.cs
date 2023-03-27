using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Catalog.Application.Common;
using Catalog.Application.Products.Commands;
using Catalog.Application.Products.Queries;
using Catalog.Application.Products.QueryViews;
using MediatR;

namespace Catalog.Api.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        #region GetAllProduct
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(QueryResult<IEnumerable<GetAllProductQueryView>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<QueryResult<IEnumerable<GetAllProductQueryView>>>> GetAllProduct()
        {
            var query = new GetAllProductQuery();
            var result = await mediator.Send(query);
            return Response(result);
        }
        #endregion

        #region CreateProduct
        [HttpPost("Create")]
        [ProducesResponseType(typeof(CommandResult),(int) HttpStatusCode.OK)]
        public async Task<ActionResult<CommandResult>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await mediator.Send(command);
            return Response(result);
        }
        #endregion
    }
}