using BussinessObject.Model;
using Repository.IRepository;
using Service.IService;
using Service.RequestAndResponse.Request.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service;

public class CheckoutService : ICheckoutService
{
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    public CheckoutService(ICartRepository cartRepository,
        IOrderRepository orderRepository,
        IProductRepository productRepository
        )
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }
    public async Task<Order> Checkout(string accountId, ShippingRequest shippingRequest, PaymentMethod paymentMethod)
    {
        var cart = await _cartRepository.GetCart(accountId);
        if (cart == null || cart.CartItem.Count < 1)
        {
            throw new Exception("Cart is empty");
        }
        foreach (var item in cart.CartItem)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductID);
            if (product == null || product.InventoryQuantity < item.Quantity)
            {
                throw new Exception("Product not found or out of stock");
            }
        }

        var order = new Order
        {
            AccountID = accountId,
            OrderDate = DateTime.Now,
            OrderDetails = cart.CartItem.Select(x => new OrderDetail
            {
                ProductID = x.ProductID,
                Quantity = x.Quantity,
                unitPrice = _productRepository.GetByIdAsync(x.ProductID).Result.PurchasePrice,
                TotalAmount = _productRepository.GetByIdAsync(x.ProductID).Result.PurchasePrice * x.Quantity
            }).ToList(),
            Status = OrderStatus.ToPay,
            ShippingInfo = new ShippingInfo
            {
                DetailAddress = shippingRequest.DetailAddress,
                Province = shippingRequest.Province,
                District = shippingRequest.District,
                Ward = shippingRequest.Ward,
                Phone = shippingRequest.Phone,
                ReceiverName = shippingRequest.ReceiverName,
                ShippingCost = CalculateShippingFee(shippingRequest.ProvinceCode)
            },
            PaymentMethod = paymentMethod == PaymentMethod.Cod ? PaymentMethod.Cod : PaymentMethod.VnPay
        };
        double total = 0;
        foreach (var item in order.OrderDetails)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductID);
            if (product != null)
            {
                total += item.Quantity * product.PurchasePrice;
                product.InventoryQuantity -= item.Quantity; // Adjust inventory
                await _productRepository.UpdateAsync(product); // Update product in repository
            }
        }

        order.Total = total + CalculateShippingFee(shippingRequest.ProvinceCode);
        await _orderRepository.AddOrderAsync(order);
        await _cartRepository.ClearCart(accountId);
        return order;
    }

    private async void ValidateCart(Cart? cart)
    {
        if (cart == null || cart.CartItem.Count < 1)
        {
            throw new Exception("Cart is empty");
        }
        foreach (var item in cart.CartItem)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductID);
            if (product == null || product.InventoryQuantity < item.Quantity)
            {
                throw new Exception("Product not found or out of stock");
            }
        }
    }

    public double CalculateShippingFee(string provinceCode)
    {
        return provinceCode == "79" ? 30000 : 50000;
    }
    public async Task<bool> ValidateCart(string accountId)
    {
        var cart = await _cartRepository.GetCart(accountId);
        if (cart == null || cart.CartItem.Count < 1)
        {
            return false;
            throw new Exception("Cart is empty");
        }
        foreach (var item in cart.CartItem)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductID);
            if (product == null || product.InventoryQuantity < item.Quantity)
            {
                return false;
                throw new Exception("Product not found or out of stock");
            }
        }
        return true;
    }

    public async Task<Order> CreateOrder(int orderId, Transaction transaction)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }
        order.Transaction = transaction;
        order.Status = OrderStatus.ToConfirm;
        await _orderRepository.UpdateAsync(order);
        return order;
    }
    public async Task<double> GetAmount(string accountId)
    {
        return await _cartRepository.GetAmount(accountId);
    }

    //not done yet
    public async Task CancelOrder(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }

        foreach (var orderDetail in order.OrderDetails)
        {
            var product = await _productRepository.GetByIdAsync(orderDetail.ProductID);
            if (product != null)
            {
                // Return the product quantity to the inventory
                product.InventoryQuantity += orderDetail.Quantity;
                await _productRepository.UpdateAsync(product);
            }
        }

        // Update the order status to Cancelled
        order.Status = OrderStatus.Cancelled;
        await _orderRepository.UpdateAsync(order);
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
}

