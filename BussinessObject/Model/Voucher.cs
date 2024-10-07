using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Voucher
    {
        [Key]
        public int VoucherID { get; set; }

        public VoucherTypes VoucherTypes { get; set; }

        public string VoucherCode { get; set; }

        public string Description { get; set; }

        public bool IsMembership { get; set; }

        public  double DiscountPercentage { get; set; }
        
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime ExpiredAt { get; set; }

        public bool Status { get; set; }


        [ForeignKey("VoucherDetailID")]
        public int? VoucherDetailID { get; set; }
        public VoucherDetail VoucherDetail { get; set; } = null!;

       /* public ICollection<Gift> Gifts { get; set; }*/





    }

    public enum VoucherTypes
    {
        Gift = 1,
        DiscountOrder = 2,
        FreeShip =3
    }
}
