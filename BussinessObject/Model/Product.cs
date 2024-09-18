using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int InventoryQuantity { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public double PurchasePrice { get; set; }
        [Required]
        public string Supplier { get; set; }
        public string Original { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Status { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Size { get; set; }
        //
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
        //
        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Report> Reports { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<ImageProduct> ImageProducts { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
