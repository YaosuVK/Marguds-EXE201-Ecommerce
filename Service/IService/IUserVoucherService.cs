using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.UserVoucher;
using Service.RequestAndResponse.Response.UserVoucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserVoucherService
    {
        Task<BaseResponse<string>> AddUserVoucherAsync(CreateUserVoucherRequest request);
        Task<BaseResponse<IEnumerable<GetAllUserVoucherResponse>>> GetAllUserVouchersAsync();
        Task<BaseResponse<GetUserVoucherByIdResponse?>> GetUserVoucherByIdAsync(int id);
        Task<BaseResponse<string>> UpdateUserVoucherAsync(UpdateUserVoucherRequest request);
        Task<BaseResponse<string>> DeleteUserVoucherAsync(int id);
        Task<BaseResponse<IEnumerable<GetAllUserVoucherResponse>>> GetAllUserUnusedVouchersAsync(string accountId);
        Task<bool> ChangeUserVoucherStatusToFalse(int id);
        Task<bool> ChangeUserVoucherStatusToTrue(int id);
        Task<bool> RenewUsedUserVoucher(int id);

    }
}
