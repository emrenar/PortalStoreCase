using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PortalStoreCase.Business.Mapping;
using PortalStoreCase.Business.Services.AddressServices;
using PortalStoreCase.Business.Services.CategoryServices;
using PortalStoreCase.Business.Services.CustomerServices;
using PortalStoreCase.Business.Services.OrderItemServices;
using PortalStoreCase.Business.Services.OrderServices;
using PortalStoreCase.Business.Services.SkuServices;
using PortalStoreCase.DataAccess.Data;
using PortalStoreCase.DataAccess.Repositories;
using PortalStoreCase.DataAccess.Repositories.EfCoreRepositories;
using PortalStoreCase.DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalStoreCase.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PortalStoreCase.WebAPI", Version = "v1" });
            });

            //services.AddScoped(IRepository<>, GenericRepository<>)();

            // Repo DI
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<ISkuRepository, EfSkuRepository>();
            services.AddScoped<IOrderItemRepository, EfOrderItemRepository>();
            services.AddScoped<IOrderRepository, EfOrderRespository>();
            services.AddScoped<IAddressRepository, EfAddressRepository>();

            // Service DI
            services.AddTransient<ICustomerServices, CustomerService>();
            services.AddTransient<ICustomerCheckService, CustomerCheckService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISkuService, SkuService>();
            services.AddTransient<IOrderItemService, OrderItemService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IAddressService, AddressService>();

            // Db Connection
            var connectionString = Configuration.GetConnectionString("SqlDb");
            services.AddDbContext<PortalDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(MapProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PortalStoreCase.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
