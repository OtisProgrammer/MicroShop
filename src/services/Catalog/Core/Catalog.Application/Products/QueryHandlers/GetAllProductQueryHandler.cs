

using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Application.Common;
using Catalog.Application.Products.Queries;
using Catalog.Application.Products.QueryViews;
using Catalog.Domain.Products.Interfaces;
using MediatR;

namespace Catalog.Application.Products.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, QueryResult<IEnumerable<GetAllProductQueryView>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<QueryResult<IEnumerable<GetAllProductQueryView>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var queryResult = new QueryResult<IEnumerable<GetAllProductQueryView>>();
            var products = await _productRepository.GetAll();
            queryResult.MessageCode = (int) HttpStatusCode.OK;
            queryResult.Message = "عملیات با موفقیت انجام شد";
            queryResult.Data = _mapper.Map<IEnumerable<GetAllProductQueryView>>(products);
            return queryResult;
        }
    }
}
