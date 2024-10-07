using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class VoucherDetail
    {
        [Key]
        public int VoucherDetailID { get; set; }

        [ForeignKey("AccountID")]
        public string? AccountID { get; set; }
        public Account Account { get; set; }


        [ForeignKey("VoucherID")]
        public int? VoucherID { get; set; }
        public Voucher Voucher { get; set; }


        [ForeignKey("GiftID")]
        public int? GiftID { get; set; }
        public Gift Gift { get; set; }


        [ForeignKey("OrderID")]
        public int? OrderID { get; set; }
        public Order? Order { get; set; } = null!;

        public bool IsUsed { get; set; }

        public DateTime UsedAt { get; set; }


    }
}
