using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Category;
using Service.RequestAndResponse.Request.Gift;
using Service.RequestAndResponse.Response.Category;
using Service.RequestAndResponse.Response.Gift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IGiftService
    {
        Task<BaseResponse<IEnumerable<GetAllGiftResponse>>> GetAllGiftFromBase();
        Task<BaseResponse<GetAllGiftResponse>> GetGiftDetailByIdFromBase(int id);
        Task<BaseResponse<UpdateGiftRequest>> UpdateGiftFromBase(int id, UpdateGiftRequest giftRequest);
        Task<BaseResponse<CreateGiftRequest>> CreateGiftFromBase(CreateGiftRequest giftRequest);
        Task<BaseResponse<IEnumerable<GetAllGiftResponse>>> GetSearchGiftFromBase(string? search, int pageIndex, int pageSize);
    }
}
