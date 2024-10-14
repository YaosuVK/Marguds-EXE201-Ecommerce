using AutoMapper;
using BussinessObject.Model;
using Repository.IRepository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Response.ImageBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ImageBlogService : IImageBlogService
    {
        private readonly IMapper _mapper;
        private readonly IImageBlogRepository _imageRepository;

        public ImageBlogService(IMapper mapper, IImageBlogRepository imageRepository)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllImageBlogResponse>>> GetAllImageProductsFromBase()
        {
            IEnumerable<ImageBlog> images = await _imageRepository.GetAllAsync();
            if (images == null)
            {
                return new BaseResponse<IEnumerable<GetAllImageBlogResponse>>("Cannot get Images",
                StatusCodeEnum.BadGateway_502, null);
            }
            var image = _mapper.Map<IEnumerable<GetAllImageBlogResponse>>(images);
            if (image == null)
            {
                return new BaseResponse<IEnumerable<GetAllImageBlogResponse>>("Cannot get Images",
                StatusCodeEnum.BadGateway_502, null);
            }
            return new BaseResponse<IEnumerable<GetAllImageBlogResponse>>("Get all image product as base success",
                StatusCodeEnum.OK_200, image);
        }
    }
}
