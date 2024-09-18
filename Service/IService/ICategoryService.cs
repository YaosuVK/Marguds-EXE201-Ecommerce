using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Category;
using Service.RequestAndResponse.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ICategoryService
    {
        Task<BaseResponse<IEnumerable<GetAllCategoryResponse>>> GetAllCategoryFromBase();
        Task<BaseResponse<GetAllCategoryResponse>> GetCategoryDetailByIdFromBase(int id);
        Task<BaseResponse<UpdateCategoryRequest>> UpdateCategoryFromBase(int id, UpdateCategoryRequest categoryRequest);
        Task<BaseResponse<CreateCategoryRequest>> CreateCategoryFromBase(CreateCategoryRequest categoryRequest);
        Task<BaseResponse<IEnumerable<GetAllCategoryResponse>>> GetSearchCategoryFromBase(string? search, int pageIndex, int pageSize);
    }
}
