using BussinessObject.Model;
using DataAccessLayer;
using Repository.BaseRepository;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly OrderDAO _orderDao;
        public OrderRepository(OrderDAO orderDao) : base(orderDao)
        {
            _orderDao = orderDao;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _orderDao.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderDao.UpdateAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync(string? search, DateTime? date, OrderStatus? status)
        {
            return await _orderDao.GetAllOrderAsync(search, date, status);
        }

        public async Task<bool> HasPurchasedProductAsync(string accountId, int productId)
        {
            return await _orderDao.HasPurchasedProductAsync(accountId, productId);
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _orderDao.GetOrderByIdAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByAccountId(string accountId)
        {
            return await _orderDao.GetOrdersByAccountId(accountId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date)
        {
            return await _orderDao.GetOrdersByDateAsync(date);
        }

        public async Task<Order> ChangeOrderStatus(int orderId, OrderStatus status)
        {
            return await _orderDao.ChangeOrderStatus(orderId, status);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            return await _orderDao.GetOrdersByStatusAsync(status);
        }
    }
}
