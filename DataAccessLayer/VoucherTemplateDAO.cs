using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VoucherTemplateDAO : BaseDAO<VoucherTemplate>
    {
        private readonly MargudsContext _context;
        public VoucherTemplateDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }

    }
}
