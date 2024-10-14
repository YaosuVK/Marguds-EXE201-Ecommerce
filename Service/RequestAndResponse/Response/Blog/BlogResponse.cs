﻿using Service.RequestAndResponse.Response.ImageBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Blog
{
    public class BlogResponse
    {
        public int BlogID { get; set; }

        public string AccountID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public bool Status { get; set; }

        public ICollection<GetAllImageBlogResponse> ImageBlogs { get; set; }
    }
}