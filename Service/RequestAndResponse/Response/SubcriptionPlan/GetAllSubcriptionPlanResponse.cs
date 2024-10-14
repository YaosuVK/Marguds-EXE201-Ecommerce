using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.SubcriptionPlan
{
    public class GetAllSubcriptionPlanResponse
    {
        public int PlanID { get; set; }

        public string PlanName { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
