using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Request.Cart
{
    public class CartRequest
    {
        public string AccountId { get; set; }
        public int ProductId { get; set; }
    }
}
