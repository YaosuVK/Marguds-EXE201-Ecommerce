using Service.RequestAndResponse.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Checkout
{
    public class OrderDetailResponse
    {
        public int Quantity { get; set; }
        public double unitPrice { get; set; }
        public double TotalAmount { get; set; }
        public GetAllProductsResponse Product { get; set; }
    }
}
