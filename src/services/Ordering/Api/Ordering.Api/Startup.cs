using System.Reflection;
using Autofac;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ordering.Application.Orders.CommandValidations;
using Ordering.Infrastructure.DependencyInjection;
using Ordering.Infrastructure.Persistence.Sql.Contexts;

namespace Ordering.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DIHandlerModule());
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<OrderDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("OrderConnectionString")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering.Api", Version = "v1" });
            }); 
            services.AddValidatorsFromAssembly(typeof(CreateOrderCommandValidation).Assembly);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering.Api v1"));
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
