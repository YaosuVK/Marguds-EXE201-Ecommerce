using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ImageProductDAO : BaseDAO<ImageProduct>
    {
        private readonly MargudsContext _context;
        public ImageProductDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }


    }
}
