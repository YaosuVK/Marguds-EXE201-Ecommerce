using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDAO : BaseDAO<Order>
    {
        private readonly MargudsContext _context;
        public OrderDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync(string? search, DateTime? date = null, OrderStatus? status = null)
        {
            IQueryable<Order> orders = _context.Orders
                .Include(o => o.Account)
                .Include(o => o.ShippingInfo)
                .Include(o => o.Transaction)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ThenInclude(p => p.ImageProducts);

            // Apply date filter if provided
            if (date.HasValue)
            {
                orders = orders.Where(o => o.OrderDate.Date == date.Value.Date);
            }

            // Apply status filter if provided
            if (status.HasValue)
            {
                orders = orders.Where(o => o.Status == status.Value);
            }

            if (!string.IsNullOrEmpty(search))
            {
                orders = orders.Where(o => o.OrderID.ToString().Contains(search.ToLower()) || o.ShippingInfo.Phone.ToLower().Contains(search.ToLower()));

            }

            // Execute the query and return the results as a list
            return await orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByAccountId(string accountId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .ThenInclude(o => o.ImageProducts)
                .Include(o => o.ShippingInfo)
                .Include(o => o.Transaction)
                .Where(o => o.AccountID == accountId)
                .ToListAsync();
        }
        public async Task<Order?> ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = status;
                await _context.SaveChangesAsync();
            }

            return await _context.Orders.FindAsync(orderId);
        }
        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> HasPurchasedProductAsync(string accountId, int productId)
        {
            return await _context.OrderDetails
                .AnyAsync(od => od.Order.AccountID == accountId && od.ProductID == productId);
        }
        public async Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date)
        {
            return await _context.Orders
                .Include(o => o.Account)
                .Include(o => o.ShippingInfo)
                .Include(o => o.Transaction)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .ThenInclude(o => o.ImageProducts)
                .Where(o => o.OrderDate.Date == date.Date)
                .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            return await _context.Orders
                .Include(o => o.Account)
                .Include(o => o.OrderDetails)
                .Where(o => o.Status == status)
                .ToListAsync();
        }
        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .ThenInclude(o => o.ImageProducts)
                .Include(o => o.ShippingInfo)
                .Include(o => o.Transaction)

                .FirstOrDefaultAsync(o => o.OrderID == orderId);
        }

        public async Task<Order?> UpdateOrderAsync(int orderId, Order order)
        {

            var existOrder = await _context.Orders.FindAsync(orderId);
            if (existOrder != null)
            {
                existOrder.ReportID = order.ReportID;
            }
            await _context.SaveChangesAsync();
            return existOrder;
        }
    }
}
