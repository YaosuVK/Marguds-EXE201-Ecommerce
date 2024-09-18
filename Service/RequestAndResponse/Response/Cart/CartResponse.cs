using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Cart
{
    public class CartResponse
    {
        public string AccountID { get; set; }
        public ICollection<CartItemResponse> CartItem { get; set; }
    }
}
