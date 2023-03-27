using Ordering.Application.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        #region Constructor
        protected readonly IMediator mediator;
        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        #endregion
        protected new ActionResult Response(CommandResult commandResult)
        {
            return StatusCode(commandResult.MessageCode, commandResult);
        }  protected new ActionResult Response<T>(QueryResult<T> commandResult) where T : class
        {
            return StatusCode(commandResult.MessageCode, commandResult);
        }
    }
}
