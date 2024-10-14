using AutoMapper;
using BussinessObject.Model;
using Repository.IRepository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Blog;
using Service.RequestAndResponse.Response.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BlogService : IBlogService
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public BlogService(IMapper mapper, IBlogRepository blogRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public async Task<BaseResponse<BlogRequest>> CreateBlogFromBase(BlogRequest request)
        {
            Blog blog = _mapper.Map<Blog>(request);
            await _blogRepository.AddAsync(blog);

            var response = _mapper.Map<BlogRequest>(request);
            return new BaseResponse<BlogRequest>("Create Blog as base success", StatusCodeEnum.Created_201, response);
        }

        public async Task<bool> DeleteBlog(int id)
        {
            var existingBlog = await _blogRepository.GetBlogByIdAsync(id);
            if (existingBlog == null)
            {
                return false;
            }
            return await _blogRepository.DeleteBlog(existingBlog);
        }

        public async Task<BaseResponse<IEnumerable<BlogResponse>>> GetAllBlogFromBase()
        {
            IEnumerable<Blog> blogs = await _blogRepository.GetAllBlogsAsync();
            if (blogs == null)
            {
                return new BaseResponse<IEnumerable<BlogResponse>>("Something went wrong!",
                StatusCodeEnum.BadGateway_502, null);
            }
            var blog = _mapper.Map<IEnumerable<BlogResponse>>(blogs);
            if (blog == null)
            {
                return new BaseResponse<IEnumerable<BlogResponse>>("Something went wrong!",
                StatusCodeEnum.BadGateway_502, null);
            }
            return new BaseResponse<IEnumerable<BlogResponse>>("Get all Blogs as base success",
                StatusCodeEnum.OK_200, blog);
        }

        public async Task<BaseResponse<BlogResponse>> GetBlogByIdFromBase(int id)
        {
            try
            {
                Blog blog = await _blogRepository.GetBlogByIdAsync(id);
                var result = _mapper.Map<BlogResponse>(blog);
                return new BaseResponse<BlogResponse>("Get Blog details success", StatusCodeEnum.OK_200, result);
            }
            catch (KeyNotFoundException ex)
            {
                return new BaseResponse<BlogResponse>(ex.Message, StatusCodeEnum.BadRequest_400, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<BlogResponse>("An error occurred while retrieving the blog.", StatusCodeEnum.BadGateway_502, null);
            }
        }
        /*public class NotFoundException : Exception
        {
            public NotFoundException(string message) : base(message) { }
        }*/


        public async Task<BaseResponse<IEnumerable<BlogResponse>>> GetSearchBlogFromBase(string search, int pageIndex, int pageSize)
        {
            IEnumerable<Blog> blogs = await _blogRepository.SearchBlogsAsync(search, pageIndex, pageSize);
            var product = _mapper.Map<IEnumerable<BlogResponse>>(blogs);
            return new BaseResponse<IEnumerable<BlogResponse>>("Get search Blog as base success",
                StatusCodeEnum.OK_200, product);
        }

        public async Task<BaseResponse<UpdateBlogRequest>> UpdateBlogFromBase(int id, UpdateBlogRequest request)
        {
            Blog existingBlog = await _blogRepository.GetBlogByIdAsync(id);
            _mapper.Map(request, existingBlog);
            await _blogRepository.UpdateAsync(existingBlog);

            var result = _mapper.Map<UpdateBlogRequest>(existingBlog);
            return new BaseResponse<UpdateBlogRequest>("Update Blog as base success", StatusCodeEnum.OK_200, result);
        }
    }
}
