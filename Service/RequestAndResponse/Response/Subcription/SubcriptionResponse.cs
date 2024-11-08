using BussinessObject.Model;
using Service.RequestAndResponse.Response.Account;
using Service.RequestAndResponse.Response.SubcriptionPlan;
using Service.RequestAndResponse.Response.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Subcription
{
    public class SubcriptionResponse
    {
        public int SubcriptionID { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

        public SubcriptionStatus Status { get; set; }

        public GetUserByStringIdResponse? Account { get; set; }

     
        public GetAllSubcriptionPlanResponse? SubscriptionPlans { get; set; }

       
        public TransactionResponse? Transaction { get; set; }


        
    }
}
