using BussinessObject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Response.Order;

namespace Marguds_EXE201_Ecommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IUserVoucherService _userVoucherService;
    private readonly IVoucherTemplateService _voucherTemplateService;

    public OrderController(IOrderService orderService, IUserVoucherService userVoucherService, IVoucherTemplateService voucherTemplateService)
    {
        _orderService = orderService;
        _userVoucherService = userVoucherService;
        _voucherTemplateService = voucherTemplateService;
    }

    /*[Authorize(Roles = "Customer")]*/
    [HttpGet("get-all-orders-by-id/{accountId}")]
    public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByAccountIdAsync(string accountId)
    {
        return await _orderService.GetAllOrdersByAccountIdAsync(accountId);
    }

    /*[Authorize(Roles = "Staff, Customer")]*/
    [HttpGet("get-all-orders")]
    public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersAsync(string? search, DateTime? date, OrderStatus? status)
    {
        return await _orderService.GetAllOrderAsync(search, date, status);
    }

    /*[Authorize(Roles = "Staff, Customer")]*/
    [HttpPut("update-order-status")]
    public async Task<BaseResponse<OrderResponse>> ChangeOrderStatus(int orderId, OrderStatus status)
    {
        return await _orderService.ChangeOrderStatus(orderId, status);
    }

    /*[Authorize(Roles = "Staff, Customer")]*/
    [HttpPut("cancel-order")]
    public async Task<BaseResponse<OrderResponse>> CancelOrder(int orderId)
    {
        var orderResponse = await _orderService.ChangeOrderStatus(orderId, OrderStatus.Cancelled);
        if (orderResponse.StatusCode != StatusCodeEnum.OK_200)
        {
            return orderResponse;
        }

        var renewResult = await _userVoucherService.RenewUsedUserVoucher(orderId);
        if (!renewResult)
        {
            return new BaseResponse<OrderResponse>(
                "Failed to renew user voucher.",
                StatusCodeEnum.InternalServerError_500,
                null
            );
        }

        return orderResponse;
    }

    /*[Authorize(Roles = "Staff, Customer")]*/
    [HttpPut("complete-order")]
    public async Task<BaseResponse<OrderResponse>> CompleteOrder(int orderId, OrderStatus status)
    {
        var orderResponse = await _orderService.ChangeOrderStatus(orderId, status);
        if (orderResponse.StatusCode != StatusCodeEnum.OK_200)
        {
            return orderResponse;
        }

        var orderDataResponse = await _orderService.GetOrderByIdAsync(orderId);
        if (orderDataResponse.StatusCode != StatusCodeEnum.OK_200 || orderDataResponse.Data == null)
        {
            return new BaseResponse<OrderResponse>(
                "Failed to retrieve order data.",
                StatusCodeEnum.NotFound_404,
                null
            );
        }

        var orderData = orderDataResponse.Data;
        var accountId = orderData.AccountID;
        var totals = orderData.Total;

        var voucherResult = await _voucherTemplateService.CheckAllActiveVoucherTemplatesAndGenerateAllSastifyUserVoucher(accountId, totals);
        if (voucherResult.StatusCode != StatusCodeEnum.OK_200)
        {
            return new BaseResponse<OrderResponse>(
                "Failed to generate vouchers for user.",
                StatusCodeEnum.InternalServerError_500,
                null
            );
        }

        return orderResponse;
    }

    /*[Authorize(Roles = "Staff, Customer")]*/
    [HttpGet("get-order-by-id/{orderId}")]
    public async Task<BaseResponse<OrderResponse>> GetOrderByIdAsync(int orderId)
    {
        return await _orderService.GetOrderByIdAsync(orderId);
    }

    //for admin Dashboard
    /*[Authorize(Roles = "Admin")]*/
    [HttpGet("adminDashBoard/GetTotalAmountTotalProductsOfWeek")]
    public async Task<BaseResponse<GetTotalAmountTotalProducts>> GetTotalAmountTotalProductsOfWeek()
    {
        return await _orderService.GetTotalAmountTotalProductsOfWeek();
    }

    /*[Authorize(Roles = "Admin")]*/
    [HttpGet("adminDashBoard/GetStaticOrders")]
    public async Task<BaseResponse<GetStaticOrders>> GetStaticOrders()
    {
        return await _orderService.GetStaticOrders();
    }

    /*[Authorize(Roles = "Admin"]*/
    [HttpGet("adminDashBoard/GetTopProductsSoldInMonth")]
    public async Task<BaseResponse<GetTopProductsSoldInMonth>> GetTopProductsSoldInMonthAsync()
    {
        return await _orderService.GetTopProductsSoldInMonthAsync();
    }

    /*[Authorize(Roles = "Admin"]*/
    [HttpGet("adminDashBoard/GetStoreRevenueByMonth")]
    public async Task<BaseResponse<GetStoreRevenueByMonth>> GetStoreRevenueByMonthAsync()
    {
        return await _orderService.GetStoreRevenueByMonthAsync();
    }

    /*[Authorize(Roles = "Admin"]*/
    [HttpGet("adminDashBoard/GetTotalOrdersTotalOrdersAmount")]
    public async Task<BaseResponse<List<GetTotalOrdersTotalOrdersAmount>>> GetTotalOrdersTotalOrdersAmountAsync(DateTime startDate, DateTime endDate, string? timeSpanType)
    {
        return await _orderService.GetTotalOrdersTotalOrdersAmountAsync(startDate, endDate, timeSpanType);
    }
}
