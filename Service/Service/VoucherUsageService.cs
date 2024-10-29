using AutoMapper;
using BussinessObject.Model;
using Repository.IRepository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.VoucherUsage;
using Service.RequestAndResponse.Response.VoucherUsage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Service
{
    public class VoucherUsageService : IVoucherUsageService
    {
        private readonly IVoucherUsageRepository _voucherUsageRepository;
        private readonly IMapper _mapper;

        public VoucherUsageService(IVoucherUsageRepository voucherUsageRepository, IMapper mapper)
        {
            _voucherUsageRepository = voucherUsageRepository;
            _mapper = mapper;
        }

        // Add VoucherUsage
        public async Task<BaseResponse<string>> AddVoucherUsageAsync(CreateVoucherUsageRequest request)
        {
            try
            {
                var voucherUsage = _mapper.Map<VoucherUsage>(request);
                await _voucherUsageRepository.AddAsync(voucherUsage);

                return new BaseResponse<string>(
                    "Voucher usage record created successfully.",
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

        // Get All VoucherUsages
        public async Task<BaseResponse<IEnumerable<GetAllVoucherUsageResponse>>> GetAllVoucherUsagesAsync()
        {
            try
            {
                var voucherUsages = await _voucherUsageRepository.GetAllAsync();
                var response = _mapper.Map<IEnumerable<GetAllVoucherUsageResponse>>(voucherUsages);

                return new BaseResponse<IEnumerable<GetAllVoucherUsageResponse>>(
                    "Voucher usage records retrieved successfully.",
                    StatusCodeEnum.OK_200,
                    response
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<GetAllVoucherUsageResponse>>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }

        // Get VoucherUsage By ID
        public async Task<BaseResponse<GetVoucherUsageByIdResponse?>> GetVoucherUsageByIdAsync(int id)
        {
            try
            {
                var voucherUsage = await _voucherUsageRepository.GetByIdAsync(id);
                if (voucherUsage == null)
                {
                    return new BaseResponse<GetVoucherUsageByIdResponse?>(
                        "Voucher usage record not found.",
                        StatusCodeEnum.NotFound_404,
                        null
                    );
                }

                var response = _mapper.Map<GetVoucherUsageByIdResponse>(voucherUsage);
                return new BaseResponse<GetVoucherUsageByIdResponse?>(
                    "Voucher usage record retrieved successfully.",
                    StatusCodeEnum.OK_200,
                    response
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<GetVoucherUsageByIdResponse?>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }

        // Update VoucherUsage
        public async Task<BaseResponse<string>> UpdateVoucherUsageAsync(UpdateVoucherUsageRequest request)
        {
            try
            {
                var voucherUsage = _mapper.Map<VoucherUsage>(request);
                await _voucherUsageRepository.UpdateAsync(voucherUsage);

                return new BaseResponse<string>(
                    "Voucher usage record updated successfully.",
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

        // Delete VoucherUsage
        public async Task<BaseResponse<string>> DeleteVoucherUsageAsync(int id)
        {
            try
            {
                var voucherUsage = await _voucherUsageRepository.GetByIdAsync(id);
                if (voucherUsage == null)
                {
                    return new BaseResponse<string>(
                        "Voucher usage record not found.",
                        StatusCodeEnum.NotFound_404,
                        null
                    );
                }

                await _voucherUsageRepository.DeleteAsync(voucherUsage);

                return new BaseResponse<string>(
                    "Voucher usage record deleted successfully.",
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
    }
}
