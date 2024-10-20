using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Gift
    {
        [Key]
        public int GiftID { get; set; }
        
        public string GiftName { get; set; }

        public int InventoryQuantity { get; set; }
        
        public string Description { get; set; }

        public bool Status { get; set; }

       /* [ForeignKey("VoucherID")]
        public int VoucherID { get; set; }
        public Voucher Voucher { get; set; }*/

        public ICollection<VoucherUsage> VoucherUsages { get; set; }
    }
}
