using Service.RequestAndResponse.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Category
{
    public class GetAllCategoryResponse
    {

        public int CategoryID { get; set; }

        public string Name { get; set; }
        //
        public ICollection<GetAllProductsResponse> Products { get; set; }
    }
}
