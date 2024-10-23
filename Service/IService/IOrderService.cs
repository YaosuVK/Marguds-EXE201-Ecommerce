using BussinessObject.Model;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IOrderService
    {
        public Task UpdateOrderStatus(int orderId, string status);
        public Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByAccountIdAsync(string accountId);
        public Task<BaseResponse<OrderResponse>> ChangeOrderStatus(int orderId, OrderStatus status);
        public Task<BaseResponse<OrderResponse>> GetOrderByIdAsync(int orderId);
        public Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrderAsync(string? search, DateTime? date, OrderStatus? status);

        // For admin DashBoard
        public Task<BaseResponse<GetTotalAmountTotalProducts>> GetTotalAmountTotalProductsOfWeek();
        public Task<BaseResponse<GetStaticOrders>> GetStaticOrders();
        public Task<BaseResponse<GetTopProductsSoldInMonth>> GetTopProductsSoldInMonthAsync();
        public Task<BaseResponse<GetStoreRevenueByMonth>> GetStoreRevenueByMonthAsync();
        public Task<BaseResponse<List<GetTotalOrdersTotalOrdersAmount>>> GetTotalOrdersTotalOrdersAmountAsync
        (DateTime startDate, DateTime endDate, string? timeSpanType);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
