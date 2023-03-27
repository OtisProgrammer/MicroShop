using AutoMapper;
using Catalog.Application.Products.Commands;
using Catalog.Application.Products.QueryViews;
using Catalog.Domain.Products.Entities;

namespace Catalog.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, GetAllProductQueryView>().ReverseMap();
            #endregion
        }
    }
}
