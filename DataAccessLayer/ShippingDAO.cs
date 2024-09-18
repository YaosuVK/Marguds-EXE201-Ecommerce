using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ShippingDAO : BaseDAO<ShippingInfo>
    {
        private readonly MargudsContext _context;
        public ShippingDAO(MargudsContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
