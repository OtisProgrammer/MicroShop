using Catalog.Application.Common;
using MediatR;

namespace Catalog.Application.Products.Commands
{
   public class CreateProductCommand:IRequest<CommandResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
