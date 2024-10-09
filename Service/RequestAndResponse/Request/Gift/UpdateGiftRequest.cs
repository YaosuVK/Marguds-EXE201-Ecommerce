using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Request.Gift
{
    public class UpdateGiftRequest
    {
        public string GiftName { get; set; }

        public int InventoryQuantity { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
