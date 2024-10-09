using AutoMapper;
using BussinessObject.Model;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Category;
using Service.RequestAndResponse.Request.Gift;
using Service.RequestAndResponse.Response.Category;
using Service.RequestAndResponse.Response.Gift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class GiftService : IGiftService
    {
        private readonly IMapper _mapper;
        private readonly IGiftRepository _giftRepository;

        public GiftService(IMapper mapper, IGiftRepository giftRepository)
        {
            _mapper = mapper;
            _giftRepository = giftRepository;
        }

        public async Task<BaseResponse<CreateGiftRequest>> CreateGiftFromBase(CreateGiftRequest giftRequest)
        {
            Gift gift = _mapper.Map<Gift>(giftRequest);
            await _giftRepository.AddAsync(gift);

            var response = _mapper.Map<CreateGiftRequest>(gift);
            return new BaseResponse<CreateGiftRequest>("Create gift as base success", StatusCodeEnum.Created_201, response);
        }

        public async Task<BaseResponse<IEnumerable<GetAllGiftResponse>>> GetAllGiftFromBase()
        {

            IEnumerable<Gift> gift = await _giftRepository.GetAllAsync();
            if (gift == null)
            {
                return new BaseResponse<IEnumerable<GetAllGiftResponse>>("Something went wrong!",
                StatusCodeEnum.BadGateway_502, null);
            }
            var gifts = _mapper.Map<IEnumerable<GetAllGiftResponse>>(gift);
            if (gifts == null)
            {
                return new BaseResponse<IEnumerable<GetAllGiftResponse>>("Something went wrong!",
                StatusCodeEnum.BadGateway_502, null);
            }
            return new BaseResponse<IEnumerable<GetAllGiftResponse>>("Get all gifts as base success",
                StatusCodeEnum.OK_200, gifts);
        }

        public async Task<BaseResponse<GetAllGiftResponse>> GetGiftDetailByIdFromBase(int id)
        {
            Gift gift = await _giftRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetAllGiftResponse>(gift);
            return new BaseResponse<GetAllGiftResponse>("Get gift details success", StatusCodeEnum.OK_200,
            result);
        }

        public async Task<BaseResponse<IEnumerable<GetAllGiftResponse>>> GetSearchGiftFromBase(string? search, int pageIndex, int pageSize)
        {
            IEnumerable<Gift> gifts = await _giftRepository.SearchGiftAsync(search, pageIndex, pageSize);
            var gift = _mapper.Map<IEnumerable<GetAllGiftResponse>>(gifts);
            return new BaseResponse<IEnumerable<GetAllGiftResponse>>("Get search gift as base success",
                StatusCodeEnum.OK_200, gift);
        }

        public async Task<BaseResponse<UpdateGiftRequest>> UpdateGiftFromBase(int id, UpdateGiftRequest giftRequest)
        {
            Gift giftExist = await _giftRepository.GetByIdAsync(id);
            _mapper.Map(giftRequest, giftExist);
            await _giftRepository.UpdateAsync(giftExist);

            var result = _mapper.Map<UpdateGiftRequest>(giftExist);
            return new BaseResponse<UpdateGiftRequest>("Update Gift as base success", StatusCodeEnum.OK_200, result);
        }
    }
}
