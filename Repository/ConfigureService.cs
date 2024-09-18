using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.BaseRepository;
using Repository.IBaseRepository;
using Repository.IRepository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureRepositoryService(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageProductRepository, ImageProductRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<ITokenRepository, TokenRepository>();

            

            //
            services.AddScoped<AccountDAO>();
            services.AddScoped<ProductDAO>();
            services.AddScoped<ImageProductDAO>();
            services.AddScoped<CartDAO>();
            services.AddScoped<OrderDAO>();
            services.AddScoped<RatingDAO>();
            services.AddScoped<CategoryDAO>();
            services.AddScoped<ReportDAO>();
            //

            return services;
        }
    }
}
