using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Blog;
using Service.RequestAndResponse.Response.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IBlogService
    {
        Task<BaseResponse<IEnumerable<BlogResponse>>> GetAllBlogFromBase();
        Task<BaseResponse<BlogResponse>> GetBlogByIdFromBase(int id);
        Task<BaseResponse<BlogRequest>> CreateBlogFromBase(BlogRequest request);
        Task<BaseResponse<UpdateBlogRequest>> UpdateBlogFromBase(int id, UpdateBlogRequest request);
        Task<Boolean> DeleteBlog(int id);
        Task<BaseResponse<IEnumerable<BlogResponse>>> GetSearchBlogFromBase(string search, int pageIndex, int pageSize);
    }
}
