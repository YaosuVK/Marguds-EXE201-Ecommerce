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
    }
}
