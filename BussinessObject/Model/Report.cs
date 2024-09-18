using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string ReportText { get; set; }
        public string ResponseText { get; set; }
        [ForeignKey("OrderID")]
        public int OrderID { get; set; }

        public Order? Order { get; set; } = null!;
        public string AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Accounts { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID ")]
        public Product Products { get; set; }

        public string? Image { get; set; }
    }
}
