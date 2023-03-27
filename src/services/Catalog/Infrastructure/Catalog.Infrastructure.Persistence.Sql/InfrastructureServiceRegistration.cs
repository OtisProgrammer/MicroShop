
using Catalog.Domain.Common;
using Catalog.Domain.Products.Interfaces;
using Catalog.Infrastructure.Persistence.Sql.Common;
using Catalog.Infrastructure.Persistence.Sql.Contexts;
using Catalog.Infrastructure.Persistence.Sql.Products.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure.Persistence.Sql
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<CatalogBbContext>(c => c.UseSqlServer(configuration.GetConnectionString("CatalogDBConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
