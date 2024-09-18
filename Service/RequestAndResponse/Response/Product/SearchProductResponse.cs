using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Product
{
    public class SearchProductResponse
    {

        public IEnumerable<GetFilterProductForManager> Products { get; set; }
        public int TotalPages { get; set; }
    }
}
