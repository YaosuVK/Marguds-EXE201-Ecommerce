using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Account;
using Service.RequestAndResponse.Response.Account;

namespace Marguds_EXE201_Ecommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountAppController : ControllerBase
{
    private readonly IAccountService _userService;
    public AccountAppController(IAccountService userService)
    {
        _userService = userService;
    }
    //
    
   /* [Authorize(Roles = "Staff, Manager, Customer")]*/
    [HttpGet]
    [Route("base/string/{id}")]
    public async Task<ActionResult<BaseResponse<GetUserByStringIdResponse>>> GetUserByStringIdFromBase(string id)
    {
        if (id.IsNullOrEmpty())
        {
            return BadRequest("Please Input userId");
        }
        return await _userService.GetUserByStringIdFromBase(id);
    }
    //
    /*[Authorize(Roles = "Admin")]*/
    [HttpGet]
    [Route("base/GetTotalAccount")]
    public async Task<BaseResponse<GetTotalAccounts>> GetTotalAccounts()
    {
        return await _userService.GetTotalAccounts();
    }
    //
    /*[Authorize(Roles = "Admin")]*/
    [HttpGet]
    [Route("base")]
    public async Task<ActionResult<BaseResponse<IEnumerable<GetAllUserResponse>>>> GetAllUserFromBase()
    {
        var users = await _userService.GetAllUserFromBase();
        return Ok(users);
    }
    //
    
    /*[Authorize(Roles = "Admin, Staff, Manager, Customer")]*/
    [HttpPut]
    [Route("base/string/{id}")]
    public async Task<ActionResult<BaseResponse<UpdateUserResponseByString>>> UpdateUserByStringFromBase(string id, [FromBody] UpdateUserRequestByString user)
    {
        if (id.IsNullOrEmpty())
        {
            return NotFound();
        }
        if (user == null)
        {
            return BadRequest("Please Inplement all the Informations");
        }
        return await _userService.UpdateUserByStringFromBase(id, user);
    }
}

