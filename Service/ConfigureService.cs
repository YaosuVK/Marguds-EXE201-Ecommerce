using DataAccessLayer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.IService;
using Service.Mapping;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureServiceService(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageProductService, ImageProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IVnPayService, VnPayService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReportService, ReportService>();
            
            services.AddScoped<IFileService, FileService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IFileService, FileService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
