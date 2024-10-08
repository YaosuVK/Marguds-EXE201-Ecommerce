﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Rating;
using Service.RequestAndResponse.Response.Rating;

namespace Marguds_EXE201_Ecommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatingController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    /*[Authorize(Roles = "Customer")]*/
    [HttpPost]
    [Route("addRating")]
    public async Task<ActionResult<BaseResponse<RatingResponse>>> AddRating(CreateRatingRequest request)
    {
        return await _ratingService.AddRating(request);
    }

    /*[Authorize(Roles = "Customer")]*/
    [HttpPut]
    [Route("updateRating")]
    public async Task<ActionResult<BaseResponse<RatingResponse>>> UpdateRatingAsync([FromBody] UpdateRatingRequest request)
    {
        return await _ratingService.UpdateRatingAsync(request);
    }

    /*[Authorize(Roles = "Customer")]*/
    [HttpDelete]
    [Route("deleteRating")]
    public async Task<ActionResult<bool>> DeleteRatingAsync(int ratingId)
    {
        return await _ratingService.DeleteRatingAsync(ratingId);
    }

    /*[Authorize(Roles = "Customer")]*/
    [HttpGet]
    [Route("getRatingByAccountId")]
    public async Task<ActionResult<BaseResponse<IEnumerable<RatingResponse>>>>
        GetRatingByAccountId(string accountId)
    {
        if (accountId == null)
        {
            return BadRequest("Please Input Id!");
        }
        return await _ratingService.GetRatingByAccountId(accountId);
    }
}

