using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public string AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Accounts { get; set; }
        public ICollection<CartItem> CartItem { get; set; } = new List<CartItem>();
    }
}
