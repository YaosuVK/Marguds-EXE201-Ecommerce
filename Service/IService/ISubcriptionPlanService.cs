using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Category;
using Service.RequestAndResponse.Request.SubcriptionPlan;
using Service.RequestAndResponse.Response.Category;
using Service.RequestAndResponse.Response.SubcriptionPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ISubcriptionPlanService
    {
        Task<BaseResponse<IEnumerable<GetAllSubcriptionPlanResponse>>> GetAllSubcriptionPlanFromBase();
        Task<BaseResponse<GetAllSubcriptionPlanResponse>> GetSubscriptionPlanByIdFromBase(int id);
        Task<BaseResponse<UpdateSubcriptionPlanRequest>> UpdateSubcriptionPlanFromBase(int id, UpdateSubcriptionPlanRequest planRequest);
        Task<BaseResponse<CreateSubcriptionPlanRequest>> CreateSubcriptionPlanFromBase(CreateSubcriptionPlanRequest planRequest);
    }
}
