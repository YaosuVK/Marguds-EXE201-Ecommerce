using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Account;
using Service.RequestAndResponse.Response.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAccountService
    {
        Task<BaseResponse<IEnumerable<GetAllUserResponse>>> GetAllUserFromBase();
     
        Task<BaseResponse<GetUserByStringIdResponse>> GetUserByStringIdFromBase(string id);
        
        Task<BaseResponse<UpdateUserResponseByString>> UpdateUserByStringFromBase(string id, UpdateUserRequestByString user);
        
        Task<BaseResponse<GetTotalAccounts>> GetTotalAccounts();
    }
}
