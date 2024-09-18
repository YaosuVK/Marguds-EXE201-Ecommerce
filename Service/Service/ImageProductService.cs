using AutoMapper;
using BussinessObject.Model;
using Repository.IRepository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Response.ImageProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ImageProductService : IImageProductService
    {
        private readonly IMapper _mapper;
        private readonly IImageProductRepository _imageRepository;

        public ImageProductService(IMapper mapper, IImageProductRepository imageRepository)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllImageProductsResponse>>> GetAllImageProductsFromBase()
        {
            IEnumerable<ImageProduct> images = await _imageRepository.GetAllAsync();
            if (images == null)
            {
                return new BaseResponse<IEnumerable<GetAllImageProductsResponse>>("Cannot get images!",
                StatusCodeEnum.BadGateway_502, null);
            }
            var image = _mapper.Map<IEnumerable<GetAllImageProductsResponse>>(images);
            if (image == null)
            {
                return new BaseResponse<IEnumerable<GetAllImageProductsResponse>>("Cannot get images!",
                StatusCodeEnum.BadGateway_502, null);
            }
            return new BaseResponse<IEnumerable<GetAllImageProductsResponse>>("Get all image product as base success",
                StatusCodeEnum.OK_200, image);
        }


    }
}
