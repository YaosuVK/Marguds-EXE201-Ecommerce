﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        //
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        //
        public string AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; }

        public string Content { get; set; }
    }
}
