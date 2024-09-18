using Service.RequestAndResponse.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Cart
{
    public class CartItemResponse
    {
        public int Quantity { get; set; }
        public GetAllProductsForManagerResponse Product { get; set; }

    }
}
