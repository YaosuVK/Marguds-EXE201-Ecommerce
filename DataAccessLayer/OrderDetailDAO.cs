using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDetailDAO : BaseDAO<OrderDetail>
    {
        private readonly MargudsContext _context;
        public OrderDetailDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }
    }
}
