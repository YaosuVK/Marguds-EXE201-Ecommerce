using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Request.Rating
{
    public class UpdateRatingRequest
    {
        public int RatingID { get; set; }
        public string AccountID { get; set; }
        public int Rate { get; set; }
        public int ProductID { get; set; }


    }
}
