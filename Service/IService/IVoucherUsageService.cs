using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.VoucherUsage;
using Service.RequestAndResponse.Response.VoucherUsage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IVoucherUsageService
    {
        Task<BaseResponse<string>> AddVoucherUsageAsync(CreateVoucherUsageRequest request);
        Task<BaseResponse<IEnumerable<GetAllVoucherUsageResponse>>> GetAllVoucherUsagesAsync();
        Task<BaseResponse<GetVoucherUsageByIdResponse?>> GetVoucherUsageByIdAsync(int id);
        Task<BaseResponse<string>> UpdateVoucherUsageAsync(UpdateVoucherUsageRequest request);
        Task<BaseResponse<string>> DeleteVoucherUsageAsync(int id);
    }
}
