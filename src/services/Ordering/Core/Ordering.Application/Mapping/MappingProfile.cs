using AutoMapper;
using Ordering.Application.Orders.Commands;
using Ordering.Domain.Orders.Entities;

namespace Ordering.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Order
            //CreateMap<Order, CreateOrderCommand>().ReverseMap();
            #endregion
        }
    }
}
