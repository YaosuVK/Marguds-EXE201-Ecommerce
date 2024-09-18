using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ICartService
    {
        public Task AddToCart(string accountId, int productId);

        public Task RemoveFromCart(string accountId, int productId);

        public Task<BaseResponse<CartResponse>> GetCart(string accountId);

        public Task ClearCart(string accountId);

        public Task<BaseResponse<CartResponse>> UpdateProductQuantityInCart(string accountId, int productId, int newQuantity);
    }
}
