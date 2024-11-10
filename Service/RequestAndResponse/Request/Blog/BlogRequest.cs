using Service.RequestAndResponse.Request.ImageProduct;
using Service.RequestAndResponse.Response.ImageBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Request.Blog
{
    public class BlogRequest
    {

        public string AccountID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public bool Status { get; set; }

        public ICollection<GetAllImageBlogResponse> ImageBlogs { get; set; }
    }
}
