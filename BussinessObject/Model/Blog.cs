﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        public string AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; }


        public ICollection<ImageBlog> ImageBlogs { get; set; }

        public bool Status { get; set; }
    }
}
