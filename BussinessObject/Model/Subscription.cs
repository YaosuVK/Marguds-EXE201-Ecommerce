using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Subscription
    {
        [Key]
        public int SubcriptionID { get; set; }

        [ForeignKey("AccountID")]
        public string? AccountID { get; set; }
        public Account Account { get; set; }

        [ForeignKey("PlanID")]
        public int? PlanID { get; set; }
        public SubcriptionPlan SubscriptionPlans { get; set; }

        public string? transactionID { get; set; }
        public Transaction? Transaction { get; set; }


        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

        public SubcriptionStatus Status { get; set; }
    }

    public enum SubcriptionStatus
    {
        Active = 1,
        Deactive = 2,
        Expired = 3
    }
}
