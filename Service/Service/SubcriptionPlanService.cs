using AutoMapper;
using BussinessObject.Model;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Category;
using Service.RequestAndResponse.Request.SubcriptionPlan;
using Service.RequestAndResponse.Response.Category;
using Service.RequestAndResponse.Response.SubcriptionPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class SubcriptionPlanService : ISubcriptionPlanService
    {
        private readonly IMapper _mapper;
        private readonly ISubcriptionPlanRepository _planRepository;

        public SubcriptionPlanService(IMapper mapper, ISubcriptionPlanRepository planRepoitory)
        {
            _mapper = mapper;
            _planRepository = planRepoitory;
        }

        public async Task<BaseResponse<CreateSubcriptionPlanRequest>> CreateSubcriptionPlanFromBase(CreateSubcriptionPlanRequest planRequest)
        {
            SubcriptionPlan plan = _mapper.Map<SubcriptionPlan>(planRequest);
            await _planRepository.AddAsync(plan);

            var response = _mapper.Map<CreateSubcriptionPlanRequest>(plan);
            return new BaseResponse<CreateSubcriptionPlanRequest>("Create subcriptionplan as base success", StatusCodeEnum.Created_201, response);
        }

        public async Task<BaseResponse<IEnumerable<GetAllSubcriptionPlanResponse>>> GetAllSubcriptionPlanFromBase()
        {
            IEnumerable<SubcriptionPlan> plan = await _planRepository.GetAllAsync();
            if (plan == null)
            {
                return new BaseResponse<IEnumerable<GetAllSubcriptionPlanResponse>>("Something went wrong!",
                StatusCodeEnum.BadGateway_502, null);
            }
            var plans = _mapper.Map<IEnumerable<GetAllSubcriptionPlanResponse>>(plan);
            if (plans == null)
            {
                return new BaseResponse<IEnumerable<GetAllSubcriptionPlanResponse>>("Something went wrong!",
                StatusCodeEnum.BadGateway_502, null);
            }
            return new BaseResponse<IEnumerable<GetAllSubcriptionPlanResponse>>("Get all category as base success",
                StatusCodeEnum.OK_200, plans);
        }

        public async Task<BaseResponse<GetAllSubcriptionPlanResponse>> GetSubscriptionPlanByIdFromBase(int id)
        {
            SubcriptionPlan plan = await _planRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetAllSubcriptionPlanResponse>(plan);
            return new BaseResponse<GetAllSubcriptionPlanResponse>("Get product details success", StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<UpdateSubcriptionPlanRequest>> UpdateSubcriptionPlanFromBase(int id, UpdateSubcriptionPlanRequest planRequest)
        {
            SubcriptionPlan planExist = await _planRepository.GetByIdAsync(id);
            _mapper.Map(planRequest, planExist);
            await _planRepository.UpdateAsync(planExist);

            var result = _mapper.Map<UpdateSubcriptionPlanRequest>(planExist);
            return new BaseResponse<UpdateSubcriptionPlanRequest>("Update Category as base success", StatusCodeEnum.OK_200, result);
        }
    }
}
