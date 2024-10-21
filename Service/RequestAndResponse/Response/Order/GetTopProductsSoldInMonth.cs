using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Order
{
    public class GetTopProductsSoldInMonth
    {
        public List<(string ProductName, int QuantitySold)> topProducts { get; set; }
    }
}
