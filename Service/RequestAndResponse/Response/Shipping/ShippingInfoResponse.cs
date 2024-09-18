using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Shipping
{
    public class ShippingInfoResponse
    {
        public string DetailAddress { get; set; }
        public string Province { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string ReceiverName { get; set; }
        public string Phone { get; set; }
        public double ShippingCost { get; set; }
    }
}
