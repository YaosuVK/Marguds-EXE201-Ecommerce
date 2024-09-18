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
    public class GetFilterProductResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        //thieu rating voi image
        public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }
        public GetCategoryResponse Category { get; set; }
        public ICollection<RatingResponse> Ratings { get; set; }
        public double AverageRating { get; set; }
    }
}
