using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Request.SubcriptionPlan
{
    public class CreateSubcriptionPlanRequest
    {
        public string PlanName { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }
    }
}
