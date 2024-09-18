using BussinessObject.Model;
using Service.RequestAndResponse.Response.Checkout;
using Service.RequestAndResponse.Response.Shipping;
using Service.RequestAndResponse.Response.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Order
{
    public class OrderResponse
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public double Total { get; set; }
        public int ReportID { get; set; }
        //
        public ICollection<OrderDetailResponse> OrderDetails { get; set; }
        public TransactionResponse? Transaction { get; set; }
        public ShippingInfoResponse ShippingInfo { get; set; } = null!;
    }
}
