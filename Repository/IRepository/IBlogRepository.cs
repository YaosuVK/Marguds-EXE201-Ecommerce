﻿using BussinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository;
public interface IBlogRepository : IBaseRepository<Blog>
{
    Task<IEnumerable<Blog>> GetAllBlogsAsync();
    Task<IEnumerable<Blog>> SearchBlogsAsync(string search, int pageIndex, int pageSize);
    Task<Blog> GetBlogByIdAsync(int id);
    Task<bool> DeleteBlog(Blog blog);
}
