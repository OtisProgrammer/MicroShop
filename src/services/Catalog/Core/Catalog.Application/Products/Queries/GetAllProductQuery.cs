using System.Collections.Generic;
using Catalog.Application.Common;
using Catalog.Application.Products.QueryViews;
using MediatR;

namespace Catalog.Application.Products.Queries
{
    public class GetAllProductQuery:IRequest<QueryResult<IEnumerable<GetAllProductQueryView>>>
    {
    }
}
