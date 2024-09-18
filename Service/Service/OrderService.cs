using AutoMapper;
using BussinessObject.Model;
using Repository.IRepository;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Order;
using Service.RequestAndResponse.Response.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task UpdateOrderStatus(int orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            order.Status = Enum.Parse<OrderStatus>(status);
            await _orderRepository.UpdateAsync(order);
        }

        public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByAccountIdAsync(string accountId)
        {
            var orders = await _orderRepository.GetOrdersByAccountId(accountId);
            var ordersResponse = _mapper.Map<IEnumerable<OrderResponse>>(orders);
            return new BaseResponse<IEnumerable<OrderResponse>>("Get ok", StatusCodeEnum.OK_200, ordersResponse);
        }

        public async Task<BaseResponse<OrderResponse>> ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var order = await _orderRepository.ChangeOrderStatus(orderId, status);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return new BaseResponse<OrderResponse>("Change status ok", StatusCodeEnum.OK_200, orderResponse);
        }

        public async Task<BaseResponse<OrderResponse>> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return new BaseResponse<OrderResponse>("Get ok", StatusCodeEnum.OK_200, orderResponse);
        }

        public async Task<BaseResponse<OrderRequest>> UpdateOrderAsync(int orderId, OrderRequest request)
        {
            var orderExist = await _orderRepository.GetByIdAsync(orderId);
            if (orderExist == null)
            {
                throw new Exception("Order not found");
            }
            orderExist.ReportID = request.ReportID;
            var OrderUpdate = await _orderRepository.UpdateAsync(orderExist);
            var orderResponse = _mapper.Map<OrderRequest>(OrderUpdate);
            return new BaseResponse<OrderRequest>("Get ok", StatusCodeEnum.OK_200, orderResponse);
        }

        public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrderAsync(string? search, DateTime? date, OrderStatus? status)
        {
            var orders = await _orderRepository.GetAllOrderAsync(search, date, status);
            var ordersResponse = _mapper.Map<IEnumerable<OrderResponse>>(orders);
            return new BaseResponse<IEnumerable<OrderResponse>>("Get ok", StatusCodeEnum.OK_200, ordersResponse);
        }
    }
}
