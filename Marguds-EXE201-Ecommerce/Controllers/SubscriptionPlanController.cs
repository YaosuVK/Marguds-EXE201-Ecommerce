using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Category;
using Service.RequestAndResponse.Request.SubcriptionPlan;
using Service.RequestAndResponse.Response.Category;
using Service.RequestAndResponse.Response.SubcriptionPlan;

namespace Marguds_EXE201_Ecommerce.Controllers;

[Route("api/category")]
[ApiController]
public class SubscriptionPlanController : ControllerBase
{
    private readonly ISubcriptionPlanService _planService;
    public SubscriptionPlanController(ISubcriptionPlanService planService)
    {
        _planService = planService;
    }
    [HttpGet]
    [Route("GetAllSubcriptionPlan")]
    public async Task<ActionResult<BaseResponse<IEnumerable<GetAllSubcriptionPlanResponse>>>> GetAllSubcriptionPlans()
    {
        var plans = await _planService.GetAllSubcriptionPlanFromBase();
        return Ok(plans);
    }

    [HttpGet]
    [Route("GetSubcriptionPlan/{id}")]
    public async Task<ActionResult<BaseResponse<GetAllSubcriptionPlanResponse>>> GetSubcriptionPlanByIdFromBase(int id)
    {
        if (id == 0 || id == null)
        {
            return BadRequest("Please Input Id!");
        }
        return await _planService.GetSubscriptionPlanByIdFromBase(id);
    }

    /*[Authorize(Roles = "Manager")]*/
    [HttpPost]
    [Route("CreateSubcriptionPlan")]
    public async Task<ActionResult<BaseResponse<CreateSubcriptionPlanRequest>>> CreateSubcriptionPlanFromBase([FromBody] CreateSubcriptionPlanRequest request)
    {
        if (request == null)
        {
            return BadRequest("Please Implement all Information");
        }
        var user = await _planService.CreateSubcriptionPlanFromBase(request);
        return user;
    }

    /*[Authorize(Roles = "Manager")]*/
    [HttpPut]
    [Route("UpdateSubscriptionPlan")]
    public async Task<ActionResult<BaseResponse<UpdateSubcriptionPlanRequest>>> UpdateSubcriptionPlanFromBase(int id,
        [FromBody] UpdateSubcriptionPlanRequest request)
    {
        if (id == 0 || id == null)
        {
            return BadRequest("Please Input Id!");
        }
        return await _planService.UpdateSubcriptionPlanFromBase(id, request);
    }
}

