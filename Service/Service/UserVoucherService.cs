using AutoMapper;
using BussinessObject.Model;
using Repository.IRepository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.UserVoucher;
using Service.RequestAndResponse.Response.UserVoucher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserVoucherService : IUserVoucherService
    {
        private readonly IUserVoucherRepository _userVoucherRepository;
        private readonly IMapper _mapper;

        public UserVoucherService(IUserVoucherRepository userVoucherRepository, IMapper mapper)
        {
            _userVoucherRepository = userVoucherRepository;
            _mapper = mapper;
        }

        // Add UserVoucher
        public async Task<BaseResponse<string>> AddUserVoucherAsync(CreateUserVoucherRequest request)
        {
            try
            {
                var userVoucher = _mapper.Map<UserVoucher>(request);
                userVoucher.VoucherCode = GenerateVoucherCode();
                await _userVoucherRepository.AddAsync(userVoucher);

                return new BaseResponse<string>(
                    "User voucher created successfully.",
                    StatusCodeEnum.OK_200,
                    "Created"
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }

        // Get All UserVouchers
        public async Task<BaseResponse<IEnumerable<GetAllUserVoucherResponse>>> GetAllUserVouchersAsync()
        {
            try
            {
                var userVouchers = await _userVoucherRepository.GetAllAsync();
                var response = _mapper.Map<IEnumerable<GetAllUserVoucherResponse>>(userVouchers);

                return new BaseResponse<IEnumerable<GetAllUserVoucherResponse>>(
                    "User vouchers retrieved successfully.",
                    StatusCodeEnum.OK_200,
                    response
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<GetAllUserVoucherResponse>>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }

        // Get UserVoucher By ID
        public async Task<BaseResponse<GetUserVoucherByIdResponse?>> GetUserVoucherByIdAsync(int id)
        {
            try
            {
                var userVoucher = await _userVoucherRepository.GetByIdAsync(id);
                if (userVoucher == null)
                {
                    return new BaseResponse<GetUserVoucherByIdResponse?>(
                        "User voucher not found.",
                        StatusCodeEnum.NotFound_404,
                        null
                    );
                }

                var response = _mapper.Map<GetUserVoucherByIdResponse>(userVoucher);
                return new BaseResponse<GetUserVoucherByIdResponse?>(
                    "User voucher retrieved successfully.",
                    StatusCodeEnum.OK_200,
                    response
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<GetUserVoucherByIdResponse?>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }

        // Update UserVoucher
        public async Task<BaseResponse<string>> UpdateUserVoucherAsync(UpdateUserVoucherRequest request)
        {
            try
            {
                var userVoucher = _mapper.Map<UserVoucher>(request);
                await _userVoucherRepository.UpdateAsync(userVoucher);

                return new BaseResponse<string>(
                    "User voucher updated successfully.",
                    StatusCodeEnum.OK_200,
                    "Updated"
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }

        // Delete UserVoucher
        public async Task<BaseResponse<string>> DeleteUserVoucherAsync(int id)
        {
            try
            {
                var userVoucher = await _userVoucherRepository.GetByIdAsync(id);
                if (userVoucher == null)
                {
                    return new BaseResponse<string>(
                        "User voucher not found.",
                        StatusCodeEnum.NotFound_404,
                        null
                    );
                }

                await _userVoucherRepository.DeleteAsync(userVoucher);

                return new BaseResponse<string>(
                    "User voucher deleted successfully.",
                    StatusCodeEnum.OK_200,
                    "Deleted"
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }
        public async Task<BaseResponse<IEnumerable<GetAllUserVoucherResponse>>> GetAllUserUnusedVouchersAsync(string accountId)
        {
            try
            {
                var userVouchers = await _userVoucherRepository.GetAllUserUnusedVouchersAsync(accountId);
                var response = _mapper.Map<IEnumerable<GetAllUserVoucherResponse>>(userVouchers);

                return new BaseResponse<IEnumerable<GetAllUserVoucherResponse>>(
                    "Unused user vouchers retrieved successfully.",
                    StatusCodeEnum.OK_200,
                    response
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<GetAllUserVoucherResponse>>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }
        // Change UserVoucher Status To False
        public async Task<bool> ChangeUserVoucherStatusToFalse(int id)
        {
            try
            {
                var userVoucher = await _userVoucherRepository.GetByIdAsync(id);
                if (userVoucher == null)
                {
                    return false;
                }

                userVoucher.Status = false;
                await _userVoucherRepository.UpdateAsync(userVoucher);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Change UserVoucher Status To True
        public async Task<bool> ChangeUserVoucherStatusToTrue(int id)
        {
            try
            {
                var userVoucher = await _userVoucherRepository.GetByIdAsync(id);
                if (userVoucher == null)
                {
                    return false;
                }

                userVoucher.Status = true;
                await _userVoucherRepository.UpdateAsync(userVoucher);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //////////////////////////////////////////
        private static Random random = new Random();

        public string GenerateVoucherCode(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder voucherCode = new StringBuilder("MG");

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                voucherCode.Append(chars[index]);
            }

            return voucherCode.ToString();
        }

        /////////////////////////////////////////
    }
}
