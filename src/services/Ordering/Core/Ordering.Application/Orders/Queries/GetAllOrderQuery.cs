using System.Collections.Generic;
using MediatR;
using Ordering.Application.Common;
using Ordering.Application.Orders.QueryViews;

namespace Ordering.Application.Orders.Queries
{
    public class GetAllOrderQuery : IRequest<QueryResult<IEnumerable<GetAllOrderQueryView>>>
    {
    }
}
