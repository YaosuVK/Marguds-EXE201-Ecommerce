using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.UserVoucher
{
    public class GetAllUserVoucherResponse
    {
        public int UserVoucherID { get; set; }

        public string VoucherCode { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime ExpiredAt { get; set; }

        public bool Status { get; set; }

        public int? VoucherTemplateID { get; set; }
        public VoucherTypes VoucherTypes { get; set; }
        public bool IsMembership { get; set; }
        public double DiscountPercentage { get; set; }

        public string? AccountID { get; set; }


    }
}
