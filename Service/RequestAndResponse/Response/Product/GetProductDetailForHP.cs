using Service.RequestAndResponse.Response.ImageProduct;
using Service.RequestAndResponse.Response.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Product
{
    public class GetProductDetailForHP
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public int InventoryQuantity { get; set; }

        public string Description { get; set; }

        public double UnitPrice { get; set; }

        public double PurchasePrice { get; set; }

        public string Supplier { get; set; }
        public string Original { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }

        public ICollection<GetRatingResponse> Ratings { get; set; }
    }
}
