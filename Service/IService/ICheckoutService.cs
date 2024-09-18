using BussinessObject.Model;
using Service.RequestAndResponse.Request.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService;

public interface ICheckoutService
{
    public Task<Order> Checkout(string accountId, ShippingRequest shippingRequest, PaymentMethod paymentMethod);
    public Task<bool> ValidateCart(string accountId);
    public Task<Order> CreateOrder(int orderId, Transaction transaction);
    public Task<double> GetAmount(string accountId);

    public double CalculateShippingFee(string provinceCode);
}

