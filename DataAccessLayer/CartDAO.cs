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
    public class CartDAO : BaseDAO<Cart>
    {
        private readonly MargudsContext _context;
        //
        public CartDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }
        //
        public async Task AddToCart(string accountId, int productId)
        {
            if (accountId == null)
            {
                throw new ArgumentNullException($"id {accountId} not found");
            }
            if (productId == null || productId <= 0)
            {
                throw new ArgumentNullException($"id {productId} not found");
            }
            var cart = await _context.Carts
                .Include(c => c.CartItem)
                .FirstOrDefaultAsync(c => c.AccountID == accountId);

            if (cart == null)
            {
                cart = new Cart { AccountID = accountId };
                _context.Carts.Add(cart);
            }

            var cartItem = cart.CartItem.FirstOrDefault(ci => ci.ProductID == productId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cartItem = new CartItem { ProductID = productId, Quantity = 1 };
                cart.CartItem.Add(cartItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCart(string accountId, int productId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException("Account ID is required.", nameof(accountId));
            }
            if (productId <= 0)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
            }
            var cart = await _context.Carts
                .Include(c => c.CartItem)
                .FirstOrDefaultAsync(c => c.AccountID == accountId);

            if (cart != null)
            {
                var cartItem = cart.CartItem.FirstOrDefault(ci => ci.ProductID == productId);

                if (cartItem != null)
                {
                    if (cartItem.Quantity > 1)
                    {
                        cartItem.Quantity--;
                    }
                    else
                    {
                        _context.CartItems.Remove(cartItem);
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<Cart?> GetCart(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException("Account ID is required.", nameof(accountId));
            }

            return await _context.Carts
                .Include(c => c.CartItem)
                .Include(ci => ci.CartItem)
                .ThenInclude(ci => ci.Product)
                .ThenInclude(p => p.ImageProducts)
                .FirstOrDefaultAsync(c => c.AccountID == accountId);

        }
        public async Task<double> GetAmount(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException("Account ID is required.", nameof(accountId));
            }
            var cart = await _context.Carts
            .Include(c => c.CartItem)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.AccountID == accountId);

            if (cart == null)
            {
                throw new Exception("Cart not found");
            }

            double totalAmount = 0;
            foreach (var item in cart.CartItem)
            {
                totalAmount += item.Product.PurchasePrice * item.Quantity;
            }

            return totalAmount;
        }

        public async Task ClearCart(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException("Account ID is required.", nameof(accountId));
            }
            var cart = await _context.Carts
                .Include(c => c.CartItem)
                .FirstOrDefaultAsync(c => c.AccountID == accountId);

            if (cart != null)
            {
                _context.CartItems.RemoveRange(cart.CartItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
