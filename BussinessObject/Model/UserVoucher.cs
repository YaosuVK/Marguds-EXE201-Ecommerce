using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class UserVoucher
    {
        [Key]
        public int UserVoucherID { get; set; }

        public string VoucherCode { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime ExpiredAt { get; set; }

        public bool Status { get; set; }

        [ForeignKey("VoucherTemplateID")]
        public int? VoucherTemplateID { get; set; }
        public VoucherTemplate VoucherTemplate { get; set; } = null!;

        public VoucherUsage VoucherUsage { get; set; } = null!;

        [ForeignKey("AccountID")]
        public string? AccountID { get; set; }
        public Account Account { get; set; }

        /* public ICollection<Gift> Gifts { get; set; }*/
    }

}
