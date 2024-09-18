using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Account
{
    public class GetTotalAccounts
    {
        public int totalAccount { get; set; }
        public int staffsAccount { get; set; }
        public int managersAccount { get; set; }
        public int customersAccount { get; set; }
    }
}
