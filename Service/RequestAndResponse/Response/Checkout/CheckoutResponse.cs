using Service.RequestAndResponse.Response.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Checkout
{
    public class CheckoutResponse
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public double Total { get; set; }
        public ICollection<OrderDetailResponse> OrderDetails { get; set; }
        public ShippingInfoResponse ShippingInfo { get; set; } = null!;
    }
}
