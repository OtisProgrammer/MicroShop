using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;
using Ordering.Application.Mapping;
using Ordering.Application.Orders.Commands;
using Ordering.Application.Orders.CommandValidations;
using Ordering.Domain.Common;
using Ordering.Domain.OrderItems.Interfaces;
using Ordering.Domain.Orders.Interfaces;
using Ordering.Infrastructure.Persistence.Sql.Common;
using Ordering.Infrastructure.Persistence.Sql.OrderItems.Repositories;
using Ordering.Infrastructure.Persistence.Sql.Orders.Repositories;

namespace Ordering.Infrastructure.DependencyInjection
{
    public class DIHandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerDependency();
            builder.RegisterType<OrderItemRepository>().As<IOrderItemRepository>().InstancePerDependency();
           
            builder.AddMediatR(typeof(CreateOrderCommand).Assembly);
            builder.RegisterAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
