using AutoMapper;
using BussinessObject.Model;
using Service.RequestAndResponse.Request.Blog;
using Service.RequestAndResponse.Request.Category;
using Service.RequestAndResponse.Request.Gift;
using Service.RequestAndResponse.Request.ImageProduct;
using Service.RequestAndResponse.Request.Order;
using Service.RequestAndResponse.Request.Product;
using Service.RequestAndResponse.Request.Rating;
using Service.RequestAndResponse.Request.Report;
using Service.RequestAndResponse.Request.SubcriptionPlan;
using Service.RequestAndResponse.Request.UserVoucher;
using Service.RequestAndResponse.Request.VoucherTemplate;
using Service.RequestAndResponse.Request.VoucherUsage;
using Service.RequestAndResponse.Response.Account;
using Service.RequestAndResponse.Response.Blog;
using Service.RequestAndResponse.Response.Cart;
using Service.RequestAndResponse.Response.Category;
using Service.RequestAndResponse.Response.Checkout;
using Service.RequestAndResponse.Response.Gift;
using Service.RequestAndResponse.Response.ImageBlog;
using Service.RequestAndResponse.Response.ImageProduct;
using Service.RequestAndResponse.Response.Order;
using Service.RequestAndResponse.Response.Product;
using Service.RequestAndResponse.Response.Rating;
using Service.RequestAndResponse.Response.Report;
using Service.RequestAndResponse.Response.Shipping;
using Service.RequestAndResponse.Response.SubcriptionPlan;
using Service.RequestAndResponse.Response.Transaction;
using Service.RequestAndResponse.Response.UserVoucher;
using Service.RequestAndResponse.Response.VoucherTemplate;
using Service.RequestAndResponse.Response.VoucherUsage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, GetAllUserResponse>();
            CreateMap<Account, UpdateUserResponseByString>();
            CreateMap<Account, GetUserByStringIdResponse>();

            //
            CreateMap<ImageBlog, GetAllImageBlogResponse>();
            CreateMap<Blog, BlogResponse>();
            CreateMap<BlogRequest, Blog>().ReverseMap();
            CreateMap<UpdateBlogRequest, Blog>().ReverseMap();

            //
            CreateMap<Product, GetAllProductsResponse>();
            CreateMap<Product, GetProductByIdResponse>();
            CreateMap<Product, GetAllProductsForManagerResponse>();
            CreateMap<Product, GetProductDetailForHP>();
            CreateMap<ImageProduct, GetAllImageProductsResponse>();
            CreateMap<UpdateProductRequest, Product>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>();
            CreateMap<AddProductRequest, Product>().ReverseMap();
            CreateMap<Product, AddProductRequest>();
            CreateMap<Product, GetFilterProductResponse>();
            CreateMap<Product, GetFilterProductForManager>();
            CreateMap<ImageProduct, ProductImage>();
            CreateMap<ProductImage, ImageProduct>().ReverseMap();

            //

            CreateMap<Category, GetAllCategoryResponse>();
            CreateMap<Category, GetCategoryResponse>();
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
            
            //

            CreateMap<Report, ReportResponse>();
            CreateMap<ReportRequest, Report>().ReverseMap();
            CreateMap<ReportRequestUpdate, Report>().ReverseMap();
            
            //

            CreateMap<Rating, GetRatingResponse>();
            CreateMap<UpdateRatingRequest, Rating>().ReverseMap();
            CreateMap<Rating, RatingResponse>();
            CreateMap<CreateRatingRequest, Rating>().ReverseMap();
            
            //

            CreateMap<Cart, CartResponse>();
            CreateMap<CartItem, CartItemResponse>();
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderDetail, OrderDetailResponse>();
            CreateMap<OrderRequest, Order>().ReverseMap();
            CreateMap<ShippingInfo, ShippingInfoResponse>();
            CreateMap<Transaction, TransactionResponse>();

            CreateMap<Gift, GetAllGiftResponse>();
            CreateMap<Gift, GetGiftResponse>();
            CreateMap<CreateGiftRequest, Gift>().ReverseMap();
            CreateMap<UpdateGiftRequest, Gift>().ReverseMap();

            CreateMap<SubcriptionPlan, GetAllSubcriptionPlanResponse>();
            CreateMap<CreateSubcriptionPlanRequest, SubcriptionPlan>().ReverseMap();
            CreateMap<UpdateSubcriptionPlanRequest, SubcriptionPlan>().ReverseMap();

            CreateMap<VoucherTemplate, GetAllVoucherTemplateResponse>(); // For getting all voucher templates
            CreateMap<CreateVoucherTemplateRequest, VoucherTemplate>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now)); // For creating a voucher template
            CreateMap<UpdateVoucherTemplateRequest, VoucherTemplate>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.Now)); // For updating a voucher template
            CreateMap<VoucherTemplate, GetVoucherTemplateByIdResponse>(); // For getting a specific voucher template by ID

            CreateMap<UserVoucher, GetAllUserVoucherResponse>() // For retrieving all user vouchers
                .ForMember(dest => dest.VoucherTypes, opt => opt.MapFrom(src => src.VoucherTemplate.VoucherTypes))
                .ForMember(dest => dest.IsMembership, opt => opt.MapFrom(src => src.VoucherTemplate.IsMembership))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.VoucherTemplate.DiscountPercentage)); 
            CreateMap<CreateUserVoucherRequest, UserVoucher>(); // For creating a user voucher
            CreateMap<UpdateUserVoucherRequest, UserVoucher>(); // For updating a user voucher
            CreateMap<UserVoucher, GetUserVoucherByIdResponse>(); // For retrieving a specific user voucher by ID

            CreateMap<VoucherUsage, GetAllVoucherUsageResponse>(); // For retrieving all voucher usage records
            CreateMap<CreateVoucherUsageRequest, VoucherUsage>(); // For creating a voucher usage record
            CreateMap<UpdateVoucherUsageRequest, VoucherUsage>(); // For updating a voucher usage record
            CreateMap<VoucherUsage, GetVoucherUsageByIdResponse>(); // For retrieving a specific voucher usage record by ID

            /*CreateMap<CreateNewUserRequest, AccountApplication>().ReverseMap();
            CreateMap<AccountApplication, CreateNewUserResponse>().ReverseMap();
            CreateMap<AccountApplication, GetUserByIdResponse>();
            CreateMap<AccountApplication, DeleteUserResponse>();
            CreateMap<AccountApplication, UpdateUserResponse>();
            CreateMap<UpdateUserRequest, AccountApplication>().ReverseMap();
            CreateMap<UpdateUserRequestByString, AccountApplication>().ReverseMap();
            //
            CreateMap<Product, ViewProductHomePageResponse>();
            
            //
            //
            //for admin dashboard
            *//*CreateMap<Order, GetStoreRevenueByMonth>();
            CreateMap<Order, GetTotalOrdersTotalOrdersAmount>();*/
        }
    }
}
