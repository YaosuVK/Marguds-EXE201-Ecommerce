using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Category;
using Service.RequestAndResponse.Request.Gift;
using Service.RequestAndResponse.Response.Category;
using Service.RequestAndResponse.Response.Gift;
using Service.Service;

namespace Marguds_EXE201_Ecommerce.Controllers;

    [Route("api/gift")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        public GiftController(IGiftService giftService)
        {
            _giftService = giftService;
    }

    [HttpGet]
    [Route("GetAllGift")]
    public async Task<ActionResult<BaseResponse<IEnumerable<GetAllGiftResponse>>>> GetAllGifts()
    {
        var gifts = await _giftService.GetAllGiftFromBase();
        return Ok(gifts);
    }

    [HttpGet]
    [Route("GetGift/{id}")]
    public async Task<ActionResult<BaseResponse<GetAllGiftResponse>>> GetGiftDetailByIdFromBase(int id)
    {
        if (id == 0 || id == null)
        {
            return BadRequest("Please Input Id!");
        }
        return await _giftService.GetGiftDetailByIdFromBase(id);
    }

    /*[Authorize(Roles = "Manager")]*/
    [HttpPost]
    [Route("CreateGift")]
    public async Task<ActionResult<BaseResponse<CreateGiftRequest>>> CreateGiftFromBase([FromBody] CreateGiftRequest request)
    {
        if (request == null)
        {
            return BadRequest("Please Implement all Information");
        }
        var gift = await _giftService.CreateGiftFromBase(request);
        return gift;
    }

    /*[Authorize(Roles = "Manager")]*/
    [HttpPut]
    [Route("UpdateCategory")]
    public async Task<ActionResult<BaseResponse<UpdateGiftRequest>>> UpdateGiftFromBase(int id,
        [FromBody] UpdateGiftRequest gift)
    {
        if (id == 0 || id == null)
        {
            return BadRequest("Please Input Id!");
        }
        return await _giftService.UpdateGiftFromBase(id, gift);
    }


    [HttpGet]
    [Route("base/search")]
    public async Task<ActionResult<BaseResponse<IEnumerable<GetAllGiftResponse>>>> GetSearchGiftFromBase(string search, int pageIndex, int pageSize)
    {
        if (string.IsNullOrEmpty(search) && pageIndex == 0 && pageSize == 0)
        {
            // Check if pageIndex is not a valid integer
            if (!int.TryParse(pageIndex.ToString(), out _))
            {
                return BadRequest("pageIndex must be a valid integer.");
            }

            // Check if pageSize is not a valid integer
            if (!int.TryParse(pageSize.ToString(), out _))
            {
                return BadRequest("pageSize must be a valid integer.");
            }

            // Continue with your logic if all conditions are met
            return BadRequest("Please Inplement all information!");
        }
        return await _giftService.GetSearchGiftFromBase(search, pageIndex, pageSize);
    }

}
    

