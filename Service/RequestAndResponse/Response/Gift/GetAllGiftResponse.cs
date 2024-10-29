using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Gift
{
    public class GetAllGiftResponse
    {
        public int GiftID { get; set; }

        public string GiftName { get; set; }

        public int InventoryQuantity { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public ICollection<BussinessObject.Model.VoucherUsage> VoucherUsages { get; set; }
    }
}
