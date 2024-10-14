using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ImageBlogDAO : BaseDAO<ImageBlog>
    {
        private readonly MargudsContext _context;
        public ImageBlogDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }



    }
}
