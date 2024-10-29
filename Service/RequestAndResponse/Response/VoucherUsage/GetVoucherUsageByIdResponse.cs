using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.VoucherUsage
{
    public class GetVoucherUsageByIdResponse
    {
        public int VoucherUsageID { get; set; }

        public string? AccountID { get; set; }

        public int? UserVoucherID { get; set; }

        public int? GiftID { get; set; }

        public int? OrderID { get; set; }

        public bool IsUsed { get; set; }

        public DateTime UsedAt { get; set; }

    }
}
