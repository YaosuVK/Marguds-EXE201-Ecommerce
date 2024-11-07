using BussinessObject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Service.IService;
using Service.RequestAndResponse.Request.Shipping;
using Service.RequestAndResponse.Request.VnPayModel;
using System.Globalization;
using Service.RequestAndResponse.Enums;
using MailKit.Search;
using Service.RequestAndResponse.Request.VoucherUsage;

namespace Marguds_EXE201_Ecommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CheckoutController : ControllerBase
{
    private readonly IVoucherTemplateService _voucherTemplateService;
    private readonly IUserVoucherService _userVoucherService;
    private readonly IVoucherUsageService _voucherUsageService;
    private readonly ICheckoutService _checkoutService;
    private readonly IVnPayService _vnPayService;
    private readonly IConfiguration _configuration;

    public CheckoutController(ICheckoutService checkoutService, IVnPayService vnPayService,
        IConfiguration configuration, IVoucherTemplateService voucherTemplateService, IUserVoucherService userVoucherService, IVoucherUsageService voucherUsageService)
    {
        _checkoutService = checkoutService;
        _vnPayService = vnPayService;
        _configuration = configuration;
        _voucherTemplateService = voucherTemplateService;
        _userVoucherService = userVoucherService;
        _voucherUsageService = voucherUsageService;
    }

    /*[Authorize(Roles = "Customer")]*/
    [HttpPost("createOrder")]
    [ProducesResponseType(StatusCodes.Status302Found)]
    public async Task<string> CreateOrder(string accountId, [FromBody] ShippingRequest shippingRequest, double totals, int userVoucherId = -1)
    {
        if(userVoucherId != -1)
        {
            var response = await _userVoucherService.GetUserVoucherByIdAsync(userVoucherId);
            if(response.StatusCode != StatusCodeEnum.OK_200)
            {
                return response.Message;
            }
            if(response.Data == null)
            {
                return "error: there is no Data";
            }
            if (response.Data.Status == false)
            {
                return "UserVoucher have already been used";
            }
            switch (response.Data.VoucherTypes)
            {
                case VoucherTypes.Gift:
                    // Not Implement Yet
                    //var shipFee01 = _checkoutService.CalculateShippingFee(shippingRequest.ProvinceCode);
                    //var recalculatedTotals01 = await _checkoutService.GetAmount(accountId) * response.Data.DiscountPercentage + shipFee01;
                    //if (recalculatedTotals01 == totals)
                    //{
                    //    var order01 = await _checkoutService.Checkout(accountId, shippingRequest, PaymentMethod.VnPay, totals, 1);
                    //    var orderId01 = order01.OrderID;
                    //    // create payment vnpay
                    //    var vnPayModel01 = new VnPayRequestModel
                    //    {
                    //        Amount = recalculatedTotals01,
                    //        CreatedDate = DateTime.Now,
                    //        Description = $"{shippingRequest.ReceiverName} {shippingRequest.Phone}",
                    //        FullName = shippingRequest.ReceiverName,
                    //        OrderId = orderId01,
                    //        OrderInfor = JsonSerializer.Serialize(new { AccountId = accountId, ShippingRequest = shippingRequest })
                    //    };
                    //    return _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel01);
                    //}
                    break;
                case VoucherTypes.DiscountOrder:
                    var shipFee02 = _checkoutService.CalculateShippingFee(shippingRequest.ProvinceCode);
                    var recalculatedTotals02 = await _checkoutService.GetAmount(accountId) * response.Data.DiscountPercentage + shipFee02;
                    if(recalculatedTotals02 == totals)
                    {
                        var order02 = await _checkoutService.Checkout(accountId, shippingRequest, PaymentMethod.VnPay, totals, 2);
                        var orderId02 = order02.OrderID;
                        var result02 = await _userVoucherService.ChangeUserVoucherStatusToFalse(userVoucherId);
                        if (result02 == false)
                        {
                            return "error: fail to update userVoucher Status";
                        }
                        var voucherUsage02 = new CreateVoucherUsageRequest
                        {
                            AccountID = accountId,
                            UserVoucherID = userVoucherId,
                            OrderID = orderId02,
                            IsUsed = true,
                            UsedAt = DateTime.UtcNow,
                        };
                        var createVoucherUsageResult = await _voucherUsageService.AddVoucherUsageAsync(voucherUsage02);
                        if (createVoucherUsageResult.StatusCode != StatusCodeEnum.OK_200)
                        {
                            return "error: fail to create4 voucherUsage Entity";
                        }
                        // create payment vnpay
                        var vnPayModel02 = new VnPayRequestModel
                        {
                            Amount = recalculatedTotals02,
                            CreatedDate = DateTime.Now,
                            Description = $"{shippingRequest.ReceiverName} {shippingRequest.Phone}",
                            FullName = shippingRequest.ReceiverName,
                            OrderId = orderId02,
                            OrderInfor = JsonSerializer.Serialize(new { AccountId = accountId, ShippingRequest = shippingRequest })
                        };
                        return _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel02);
                    }
                    else
                        return "error: recalculatedTotals not the same as totals";
                case VoucherTypes.FreeShip:
                    var recalculatedTotals03 = await _checkoutService.GetAmount(accountId) * response.Data.DiscountPercentage;
                    if (recalculatedTotals03 == totals)
                    {
                        var order03 = await _checkoutService.Checkout(accountId, shippingRequest, PaymentMethod.VnPay, totals, 3);
                        var orderId03 = order03.OrderID;
                        var result03 = await _userVoucherService.ChangeUserVoucherStatusToFalse(userVoucherId);
                        if (result03 == false)
                        {
                            return "error: fail to update userVoucher Status";
                        }
                        var voucherUsage03 = new CreateVoucherUsageRequest
                        {
                            AccountID = accountId,
                            UserVoucherID = userVoucherId,
                            OrderID = orderId03,
                            IsUsed = true,
                            UsedAt = DateTime.UtcNow,
                        };
                        var createVoucherUsageResult = await _voucherUsageService.AddVoucherUsageAsync(voucherUsage03);
                        if (createVoucherUsageResult.StatusCode != StatusCodeEnum.OK_200)
                        {
                            return "error: fail to create4 voucherUsage Entity";
                        }
                        // create payment vnpay
                        var vnPayModel03 = new VnPayRequestModel
                        {
                            Amount = recalculatedTotals03,
                            CreatedDate = DateTime.Now,
                            Description = $"{shippingRequest.ReceiverName} {shippingRequest.Phone}",
                            FullName = shippingRequest.ReceiverName,
                            OrderId = orderId03,
                            OrderInfor = JsonSerializer.Serialize(new { AccountId = accountId, ShippingRequest = shippingRequest })
                        };
                        return _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel03);
                    }
                    else
                        return "error: recalculatedTotals not the same as totals";
            }
        }
        var ShipFee = _checkoutService.CalculateShippingFee(shippingRequest.ProvinceCode);
        var recalculatedTotals = await _checkoutService.GetAmount(accountId) + ShipFee;
        if (recalculatedTotals == totals)
        {
            var order = await _checkoutService.Checkout(accountId, shippingRequest, PaymentMethod.VnPay, totals);
            var orderId = order.OrderID;
            var result = await _userVoucherService.ChangeUserVoucherStatusToFalse(userVoucherId);
            if (result == false)
            {
                return "error: fail to update userVoucher Status";
            }
            var voucherUsage = new CreateVoucherUsageRequest
            {
                AccountID = accountId,
                UserVoucherID = userVoucherId,
                OrderID = orderId,
                IsUsed = true,
                UsedAt = DateTime.UtcNow,
            };
            var createVoucherUsageResult = await _voucherUsageService.AddVoucherUsageAsync(voucherUsage);
            if (createVoucherUsageResult.StatusCode != StatusCodeEnum.OK_200)
            {
                return "error: fail to create4 voucherUsage Entity";
            }// create payment vnpay
            var vnPayModel = new VnPayRequestModel
            {
                Amount = recalculatedTotals,
                CreatedDate = DateTime.Now,
                Description = $"{shippingRequest.ReceiverName} {shippingRequest.Phone}",
                FullName = shippingRequest.ReceiverName,
                OrderId = orderId,
                OrderInfor = JsonSerializer.Serialize(new { AccountId = accountId, ShippingRequest = shippingRequest })
            };
            return _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel);
        }
        else
            return "error: recalculatedTotals not the same as totals";
    }

    /*[Authorize(Roles = "Customer, Staff")]*/
    //[HttpPost("createOrder-cod")]
    //public async Task<Order> CreateOrderWithPaymentMethodCod(string accountId, [FromBody] ShippingRequest shippingRequest)
    //{
    //    var order = await _checkoutService.Checkout(accountId, shippingRequest, PaymentMethod.Cod);
    //    return order;
    //}

    /*[Authorize(Roles = "Customer")]*/
    [HttpGet("vnpay-return")]
    public async Task<IActionResult> HandleVnPayReturn([FromQuery] VnPayReturnModel model)
    {
        if (model.Vnp_TransactionStatus != "00") return BadRequest();
        var transaction = new Transaction
        {
            Amount = model.Vnp_Amount,
            BankCode = model.Vnp_BankCode,
            BankTranNo = model.Vnp_BankTranNo,
            TransactionType = model.Vnp_CardType,
            OrderInfo = model.Vnp_OrderInfo,
            PayDate = DateTime.ParseExact((string)model.Vnp_PayDate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
            ResponseCode = model.Vnp_ResponseCode,
            TmnCode = model.Vnp_TmnCode,
            TransactionNo = model.Vnp_TransactionNo,
            TransactionStatus = model.Vnp_TransactionStatus,
            TxnRef = model.Vnp_TxnRef,
            SecureHash = model.Vnp_SecureHash,
            ResponseId = model.Vnp_TransactionNo,
            Message = model.Vnp_ResponseCode
        };
        var orderId = Convert.ToInt32(model.Vnp_OrderInfo);
        await _checkoutService.CreateOrder(orderId, transaction);
        return Redirect($"{_configuration["VnPay:UrlReturnPayment"]}/{orderId}");
    }


}

