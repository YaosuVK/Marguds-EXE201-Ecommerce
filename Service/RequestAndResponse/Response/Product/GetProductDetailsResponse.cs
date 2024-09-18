using Service.RequestAndResponse.Response.Category;
using Service.RequestAndResponse.Response.ImageProduct;
using Service.RequestAndResponse.Response.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Product
{
    public class GetProductDetailsResponse
    {
        public string Name { get; set; }

        public int InventoryQuantity { get; set; }

        public string Description { get; set; }
        public double PurchasePrice { get; set; }

        public string Supplier { get; set; }
        public string Original { get; set; }

        public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }

        public GetCategoryResponse Category { get; set; }
        public ICollection<RatingResponse> Ratings { get; set; }

    }
}
