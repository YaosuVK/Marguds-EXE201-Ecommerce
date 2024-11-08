using AutoMapper;
using BussinessObject.Model;
using MailKit.Search;
using Repository.IRepository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.UserVoucher;
using Service.RequestAndResponse.Request.VoucherTemplate;
using Service.RequestAndResponse.Response.Order;
using Service.RequestAndResponse.Response.VoucherTemplate;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class VoucherTemplateService : IVoucherTemplateService
    {
        private readonly IUserVoucherService _userVoucherService;
        private readonly IVoucherTemplateRepository _voucherTemplateRepository;
        private readonly IMapper _mapper;
        public VoucherTemplateService(IVoucherTemplateRepository voucherTemplateRepository, IUserVoucherService userVoucherService, IMapper mapper)
        {
            _voucherTemplateRepository = voucherTemplateRepository;
            _userVoucherService = userVoucherService;
            _mapper = mapper;
        }
        // Add Voucher Template
        public async Task<BaseResponse<string>> AddVoucherTemplateAsync(CreateVoucherTemplateRequest request)
        {
            try
            {
                var voucherTemplate = _mapper.Map<VoucherTemplate>(request);
                await _voucherTemplateRepository.AddAsync(voucherTemplate);

                return new BaseResponse<string>(
                    "Voucher template created successfully.",
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

        // Get All Voucher Templates
        public async Task<BaseResponse<IEnumerable<GetAllVoucherTemplateResponse>>> GetAllVoucherTemplatesAsync()
        {
            try
            {
                var voucherTemplates = await _voucherTemplateRepository.GetAllAsync();
                var voucherTemplatesResponse = _mapper.Map<IEnumerable<GetAllVoucherTemplateResponse>>(voucherTemplates);

                return new BaseResponse<IEnumerable<GetAllVoucherTemplateResponse>>(
                    "Voucher templates retrieved successfully.",
                    StatusCodeEnum.OK_200,
                    voucherTemplatesResponse
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<GetAllVoucherTemplateResponse>>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }

        // Get Voucher Template By ID
        public async Task<BaseResponse<GetVoucherTemplateByIdResponse?>> GetVoucherTemplateByIdAsync(int id)
        {
            try
            {
                var voucherTemplate = await _voucherTemplateRepository.GetByIdAsync(id);
                if (voucherTemplate == null)
                {
                    return new BaseResponse<GetVoucherTemplateByIdResponse?>(
                        "Voucher template not found.",
                        StatusCodeEnum.NotFound_404,
                        null
                    );
                }

                var response = _mapper.Map<GetVoucherTemplateByIdResponse>(voucherTemplate);
                return new BaseResponse<GetVoucherTemplateByIdResponse?>(
                    "Voucher template retrieved successfully.",
                    StatusCodeEnum.OK_200,
                    response
                );
            }
            catch (Exception ex)
            {
                return new BaseResponse<GetVoucherTemplateByIdResponse?>(
                    $"Error: {ex.Message}",
                    StatusCodeEnum.InternalServerError_500,
                    null
                );
            }
        }

        // Update Voucher Template
        public async Task<BaseResponse<string>> UpdateVoucherTemplateAsync(UpdateVoucherTemplateRequest request)
        {
            try
            {
                var voucherTemplate = _mapper.Map<VoucherTemplate>(request);
                await _voucherTemplateRepository.UpdateAsync(voucherTemplate);

                return new BaseResponse<string>(
                    "Voucher template updated successfully.",
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

        // Delete Voucher Template
        public async Task<BaseResponse<string>> DeleteVoucherTemplateAsync(int id)
        {
            try
            {
                var voucherTemplate = await _voucherTemplateRepository.GetByIdAsync(id);
                if (voucherTemplate == null)
                {
                    return new BaseResponse<string>(
                        "Voucher template not found.",
                        StatusCodeEnum.NotFound_404,
                        null
                    );
                }

                await _voucherTemplateRepository.DeleteAsync(voucherTemplate);

                return new BaseResponse<string>(
                    "Voucher template deleted successfully.",
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
        public async Task<BaseResponse<string>> CheckAllActiveVoucherTemplatesAndGenerateAllSastifyUserVoucher(string accountId, double totals)
        {
            try
            {
                // Get all voucher templates that have Status = true and MilestoneAmount <= totals
                var allVoucherTemplatesResponse = await GetAllVoucherTemplatesAsync();
                if (allVoucherTemplatesResponse.StatusCode != StatusCodeEnum.OK_200 || allVoucherTemplatesResponse.Data == null)
                {
                    return new BaseResponse<string>(
                        "Failed to retrieve voucher templates.",
                        StatusCodeEnum.InternalServerError_500,
                        null
                    );
                }

                var satisfiedVoucherTemplates = allVoucherTemplatesResponse.Data
                    .Where(voucher => voucher.Status && voucher.MilestoneAmount <= totals);

                // Generate vouchers for each satisfied template
                foreach (var voucherTemplate in satisfiedVoucherTemplates)
                {
                    var createUserVoucherRequest = new CreateUserVoucherRequest
                    {
                        AccountID = accountId,
                        VoucherTemplateID = voucherTemplate.VoucherTemplateID,
                        StartedAt = DateTime.Now,
                        ExpiredAt = voucherTemplate.ExpiredAt,
                        Status = true
                    };

                    var addUserVoucherResponse = await _userVoucherService.AddUserVoucherAsync(createUserVoucherRequest);
                    if (addUserVoucherResponse.StatusCode != StatusCodeEnum.OK_200)
                    {
                        return new BaseResponse<string>(
                            $"Failed to add user voucher for template ID {voucherTemplate.VoucherTemplateID}.",
                            StatusCodeEnum.InternalServerError_500,
                            null
                        );
                    }
                }

                return new BaseResponse<string>(
                    "Vouchers generated successfully.",
                    StatusCodeEnum.OK_200,
                    "Success"
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
