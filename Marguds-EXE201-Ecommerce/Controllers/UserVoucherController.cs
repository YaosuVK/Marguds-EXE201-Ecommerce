using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.UserVoucher;
using Service.RequestAndResponse.Response.UserVoucher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marguds_EXE201_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVoucherController : ControllerBase
    {
        private readonly IUserVoucherService _userVoucherService;

        public UserVoucherController(IUserVoucherService userVoucherService)
        {
            _userVoucherService = userVoucherService;
        }

        // GET: api/uservoucher/all
        [HttpGet("all")]
        public async Task<BaseResponse<IEnumerable<GetAllUserVoucherResponse>>> GetAllUserVouchersAsync()
        {
            return await _userVoucherService.GetAllUserVouchersAsync();
        }

        // GET: api/uservoucher/{id}
        [HttpGet("{id:int}")]
        public async Task<BaseResponse<GetUserVoucherByIdResponse?>> GetUserVoucherByIdAsync(int id)
        {
            return await _userVoucherService.GetUserVoucherByIdAsync(id);
        }

        //// POST: api/uservoucher
        //[HttpPost]
        //public async Task<BaseResponse<string>> CreateUserVoucherAsync([FromBody] CreateUserVoucherRequest request)
        //{
        //    return await _userVoucherService.AddUserVoucherAsync(request);
        //}

        // PUT: api/uservoucher
        [HttpPut]
        public async Task<BaseResponse<string>> UpdateUserVoucherAsync([FromBody] UpdateUserVoucherRequest request)
        {
            return await _userVoucherService.UpdateUserVoucherAsync(request);
        }

        // DELETE: api/uservoucher/{id}
        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<string>> DeleteUserVoucherAsync(int id)
        {
            return await _userVoucherService.DeleteUserVoucherAsync(id);
        }
    }
}
