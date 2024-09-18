using BussinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        public Task AddToCart(string accountId, int productId);
        public Task RemoveFromCart(string accountId, int productId);
        public Task<Cart?> GetCart(string accountId);
        public Task ClearCart(string accountId);
        public Task<double> GetAmount(string accountId);
    }
}
