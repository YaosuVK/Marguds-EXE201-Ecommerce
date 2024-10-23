using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VoucherUsageDAO : BaseDAO<VoucherUsage>
    {
        private readonly MargudsContext _context;
        public VoucherUsageDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }

    }
}
