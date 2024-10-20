using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Account : IdentityUser
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string? Image { get; set; }

        public bool Status { get; set; }

        public DateTime DateOfBirth { get; set; }
        

        //public ICollection<CartItem> CartItems { get; set; }

        public int? SubcriptionID { get; set; }
        public Subscription Subscription { get; set; }

        public ICollection<Blog> Blogs { get; set; }


        public ICollection<Report> Reports { get; set; }


        public ICollection<Order> Orders { get; set; }


        public ICollection<Review> Reviews { get; set; }

        public ICollection<VoucherUsage> VoucherUsages { get; set; }

        public ICollection<UserVoucher> UserVouchers { get; set; }
    }
}
