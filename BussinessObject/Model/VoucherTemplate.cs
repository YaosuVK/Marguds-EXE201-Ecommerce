using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class VoucherTemplate
    {
        [Key]
        public int VoucherTemplateID { get; set; }

        public string Name { get; set; }

        public double MilestoneAmount { get; set; }

        public VoucherTypes VoucherTypes { get; set; }

        public string Description { get; set; }

        public bool IsMembership { get; set; }

        public double DiscountPercentage { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime ExpiredAt { get; set; }

        public bool Status { get; set; }


        public ICollection<UserVoucher> UserVouchers { get; set; }

        /* public ICollection<Gift> Gifts { get; set; }*/
    }

    public enum VoucherTypes
    {
        Gift = 1,
        DiscountOrder = 2,
        FreeShip = 3
    }
}

