using AutoMapper;
using BussinessObject.Model;
using Repository.IRepository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Account;
using Service.RequestAndResponse.Response.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountAppRepository;
        public AccountService(IMapper mapper, IAccountRepository accountAppRepository)
        {
            _mapper = mapper;
            _accountAppRepository = accountAppRepository;
        }
        public async Task<BaseResponse<IEnumerable<GetAllUserResponse>>> GetAllUserFromBase()
        {
            IEnumerable<Account> users = await _accountAppRepository.GetAllAsync();
            var user = _mapper.Map<IEnumerable<GetAllUserResponse>>(users);
            if (user != null)
            {
                return new BaseResponse<IEnumerable<GetAllUserResponse>>("Get all user as base success",
                StatusCodeEnum.OK_200, user);
            }
            else
            {
                return new BaseResponse<IEnumerable<GetAllUserResponse>>("Get all user as base fail",
                StatusCodeEnum.BadGateway_502, user);
            }
        }

        public Task<BaseResponse<GetTotalAccounts>> GetTotalAccounts()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<GetUserByStringIdResponse>> GetUserByStringIdFromBase(string id)
        {
            Account user = await _accountAppRepository.GetByStringId(id);
            var result = _mapper.Map<GetUserByStringIdResponse>(user);
            return new BaseResponse<GetUserByStringIdResponse>("Get user by id as base success", StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<UpdateUserResponseByString>> UpdateUserByStringFromBase(string id, UpdateUserRequestByString request)
        {
            Account user = await _accountAppRepository.GetByStringId(id);
            _mapper.Map(request, user);
            await _accountAppRepository.UpdateAsync(user);

            var result = _mapper.Map<UpdateUserResponseByString>(user);
            return new BaseResponse<UpdateUserResponseByString>("Update user as base success", StatusCodeEnum.OK_200, result);
        }
    }
}
