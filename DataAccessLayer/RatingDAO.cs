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
    public class RatingDAO : BaseDAO<Rating>
    {
        private readonly MargudsContext _context;
        public RatingDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }

        //get avaerage rating of product
        public async Task<double> GetAverageRating(int productId)
        {
            if (productId <= 0)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
            }
            var ratings = await _context.Rating
                .Where(r => r.ProductID == productId)
                .ToListAsync();

            if (ratings.Count == 0)
            {
                return 0;
            }

            var sum = ratings.Sum(r => r.Rate);
            var average = (double)sum / ratings.Count;

            return average;
        }
        public async Task<IEnumerable<Rating?>> GetRatingByProductId(int productId)
        {
            if (productId <= 0)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
            }
            var entity = await _context.Rating
                .Where(r => r.ProductID == productId)
                .ToListAsync();
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {productId} not found");
            }
            return entity;
        }
        public async Task<IEnumerable<Rating?>> GetRatingByAccountId(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException("Account ID is required.", nameof(accountId));
            }
            var entity = await _context.Rating
                .Where(r => r.AccountID == accountId)
                .ToListAsync();
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {accountId} not found");
            }
            return entity;
        }

        public async Task<Rating?> GetRatingByUserIdAndProduct(string accountId, int productId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException("Account ID is required.", nameof(accountId));
            }
            if (productId <= 0)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
            }

            var entity = await _context.Rating
                .Where(r => r.AccountID == accountId && r.ProductID == productId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                // It's better to return null if the entity is not found rather than throwing an exception
                return null;
            }

            return entity;
        }
    }
}
