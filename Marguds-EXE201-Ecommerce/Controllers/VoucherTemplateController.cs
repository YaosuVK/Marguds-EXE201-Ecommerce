using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.VoucherTemplate;
using Service.RequestAndResponse.Response.VoucherTemplate;
using Service.RequestAndResponse.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marguds_EXE201_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherTemplateController : ControllerBase
    {
        private readonly IVoucherTemplateService _voucherTemplateService;

        public VoucherTemplateController(IVoucherTemplateService voucherTemplateService)
        {
            _voucherTemplateService = voucherTemplateService;
        }

        // GET: api/vouchertemplate/all
        [HttpGet("all")]
        public async Task<BaseResponse<IEnumerable<GetAllVoucherTemplateResponse>>> GetAllVoucherTemplatesAsync()
        {
            return await _voucherTemplateService.GetAllVoucherTemplatesAsync();
        }

        // GET: api/vouchertemplate/{id}
        [HttpGet("{id:int}")]
        public async Task<BaseResponse<GetVoucherTemplateByIdResponse?>> GetVoucherTemplateByIdAsync(int id)
        {
            return await _voucherTemplateService.GetVoucherTemplateByIdAsync(id);
        }

        // POST: api/vouchertemplate
        [HttpPost]
        public async Task<BaseResponse<string>> CreateVoucherTemplateAsync([FromBody] CreateVoucherTemplateRequest request)
        {
            return await _voucherTemplateService.AddVoucherTemplateAsync(request);
        }

        // PUT: api/vouchertemplate
        [HttpPut]
        public async Task<BaseResponse<string>> UpdateVoucherTemplateAsync([FromBody] UpdateVoucherTemplateRequest request)
        {
            return await _voucherTemplateService.UpdateVoucherTemplateAsync(request);
        }

        // DELETE: api/vouchertemplate/{id}
        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<string>> DeleteVoucherTemplateAsync(int id)
        {
            return await _voucherTemplateService.DeleteVoucherTemplateAsync(id);
        }
    }
}
