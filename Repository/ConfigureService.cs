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
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageProductRepository, ImageProductRepository>();
            services.AddScoped<IImageBlogRepository, ImageBlogRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddScoped<IGiftRepository, GiftRepository>();
            services.AddScoped<ISubcriptionPlanRepository, SubcriptionPlanRepository>();
            services.AddScoped<ISubcriptionRepository, SubcriptionRepository>();
            services.AddScoped<IVoucherTemplateRepository, VoucherTemplateRepository>();
            services.AddScoped<IUserVoucherRepository, UserVoucherRepository>();
            services.AddScoped<IVoucherUsageRepository, VoucherUsageRepository>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));


            //
            services.AddScoped<AccountDAO>();
            services.AddScoped<BlogDAO>();
            services.AddScoped<ProductDAO>();
            services.AddScoped<ImageProductDAO>();
            services.AddScoped<ImageBlogDAO>();
            services.AddScoped<CartDAO>();
            services.AddScoped<OrderDAO>();
            services.AddScoped<RatingDAO>();
            services.AddScoped<CategoryDAO>();
            services.AddScoped<ReportDAO>();
            services.AddScoped<GiftDAO>();
            services.AddScoped<SubcriptionPlanDAO>();
            services.AddScoped<SubcriptionDAO>();

            //

            return services;
        }
    }
}
