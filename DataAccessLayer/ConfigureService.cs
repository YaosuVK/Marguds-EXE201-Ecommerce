using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using DataAccessLayer.IBaseDAO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureDataAccessObjectService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<Account>();
            services.AddScoped<Product>();
            services.AddScoped<ImageProduct>();
            services.AddScoped<Cart>();
            services.AddScoped<Category>();
            services.AddScoped<Order>();
            services.AddScoped<OrderDetail>();
            services.AddScoped<Report>();
            services.AddScoped<ShippingInfo>();
            services.AddScoped<Transaction>();
            services.AddScoped<Rating>();
            services.AddScoped(typeof(IBaseDAO<>), typeof(BaseDAO<>));
            return services;
        }
    }
}
