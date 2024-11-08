using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.VoucherUsage;
using Service.RequestAndResponse.Response.VoucherUsage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marguds_EXE201_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherUsageController : ControllerBase
    {
        private readonly IVoucherUsageService _voucherUsageService;

        public VoucherUsageController(IVoucherUsageService voucherUsageService)
        {
            _voucherUsageService = voucherUsageService;
        }

        // GET: api/voucherusage/all
        [HttpGet("all")]
        public async Task<BaseResponse<IEnumerable<GetAllVoucherUsageResponse>>> GetAllVoucherUsagesAsync()
        {
            return await _voucherUsageService.GetAllVoucherUsagesAsync();
        }

        // GET: api/voucherusage/{id}
        [HttpGet("{id:int}")]
        public async Task<BaseResponse<GetVoucherUsageByIdResponse?>> GetVoucherUsageByIdAsync(int id)
        {
            return await _voucherUsageService.GetVoucherUsageByIdAsync(id);
        }

        // POST: api/voucherusage
        [HttpPost]
        public async Task<BaseResponse<string>> AddVoucherUsageAsync([FromBody] CreateVoucherUsageRequest request)
        {
            return await _voucherUsageService.AddVoucherUsageAsync(request);
        }

        // PUT: api/voucherusage
        [HttpPut]
        public async Task<BaseResponse<string>> UpdateVoucherUsageAsync([FromBody] UpdateVoucherUsageRequest request)
        {
            return await _voucherUsageService.UpdateVoucherUsageAsync(request);
        }

        // DELETE: api/voucherusage/{id}
        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<string>> DeleteVoucherUsageAsync(int id)
        {
            return await _voucherUsageService.DeleteVoucherUsageAsync(id);
        }
    }
}
