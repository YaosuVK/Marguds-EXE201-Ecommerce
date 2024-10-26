using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.VoucherTemplate;
using Service.RequestAndResponse.Response.VoucherTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IVoucherTemplateService
    {
        Task<BaseResponse<string>> AddVoucherTemplateAsync(CreateVoucherTemplateRequest request);
        Task<BaseResponse<IEnumerable<GetAllVoucherTemplateResponse>>> GetAllVoucherTemplatesAsync();
        Task<BaseResponse<GetVoucherTemplateByIdResponse?>> GetVoucherTemplateByIdAsync(int id);
        Task<BaseResponse<string>> UpdateVoucherTemplateAsync(UpdateVoucherTemplateRequest request);
        Task<BaseResponse<string>> DeleteVoucherTemplateAsync(int id);
    }
}
