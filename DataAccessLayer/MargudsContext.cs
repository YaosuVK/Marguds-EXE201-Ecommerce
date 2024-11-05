using BussinessObject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MargudsContext : IdentityDbContext<Account>
    {
        public MargudsContext() : base()
        { }
        public MargudsContext(DbContextOptions<MargudsContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasOne(e => e.Order)
            .WithOne(e => e.Transaction)
                .HasForeignKey<Order>(e => e.transactionID);

            modelBuilder.Entity<Transaction>()
                .HasOne(e => e.Subscription)
            .WithOne(e => e.Transaction)
                .HasForeignKey<Subscription>(e => e.transactionID);

            modelBuilder.Entity<ShippingInfo>()
                .HasOne(e => e.Order)
                .WithOne(e => e.ShippingInfo)
                .HasForeignKey<Order>(e => e.ShippingInforID);

            modelBuilder.Entity<Report>()
                .HasOne(e => e.Order)
                .WithOne(e => e.Report)
                .HasForeignKey<Order>(e => e.ReportID);

            modelBuilder.Entity<Subscription>()
                .HasOne(e => e.Account)
                .WithOne(e => e.Subscription)
                .HasForeignKey<Account>(e => e.SubcriptionID);
                
            modelBuilder.Entity<VoucherUsage>()
                .HasOne(e => e.UserVoucher)
                .WithOne(e => e.VoucherUsage)
                .HasForeignKey<VoucherUsage>(e => e.UserVoucherID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VoucherUsage>()
                .HasOne(e => e.Order)
                .WithOne(e => e.VoucherUsage)
                .HasForeignKey<VoucherUsage>(e => e.OrderID)
                .OnDelete(DeleteBehavior.NoAction);
                


            List<IdentityRole> roles = new List<IdentityRole>
              {
                  new IdentityRole
                  {
                      Name = "Admin",
                      NormalizedName = "ADMIN"
                  },
                  new IdentityRole
                  {
                      Name = "Customer",
                      NormalizedName = "CUSTOMER"
                  },
                  new IdentityRole
                 {
                      Name = "Staff",
                      NormalizedName = "STAFF"
                  },
                  new IdentityRole
                  {
                      Name = "Manager",
                      NormalizedName = "MANAGER"
                  },
                  new IdentityRole
                  {
                      Name = "Shipper",
                      NormalizedName = "SHIPPER"
                  } 
             };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<CartItem> CartItems { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<ImageBlog> ImageBlogs { set; get; }
        public DbSet<ImageProduct> ImageProducts { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Rating?> Rating { set; get; }
        public DbSet<Report> Reports { set; get; }
        public DbSet<Review> Reviews { set; get; }
        public DbSet<RefreshToken> RefreshTokens { set; get; }
        public DbSet<ShippingInfo> ShippingInfo { set; get; }
        public DbSet<Transaction> Transaction { set; get; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubcriptionPlan> SubcriptionPlans { set; get; }
        public DbSet<VoucherTemplate> VoucherTemplates { set; get; }
        public DbSet<UserVoucher> UserVouchers { set; get; }
        public DbSet<VoucherUsage> VoucherUsages { set; get; }
        public DbSet<Gift> Gifts { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(GetConnectionString());
                }
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Marguds-EXE201-Ecommerce"))
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .Build();
            var strConn = config["ConnectionStrings:DbConnection"];

            return strConn;
        }
    }
}
