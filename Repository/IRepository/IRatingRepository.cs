using BussinessObject.Model;
using Repository.BaseRepository;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRatingRepository : IBaseRepository<Rating>
    {
        public Task<double> GetAverageRating(int productId);
        public Task<IEnumerable<Rating?>> GetRatingByProductId(int productId);
        public Task<IEnumerable<Rating?>> GetRatingByAccountId(string accountId);
        public Task<Rating?> GetRatingByUserIdAndProduct(string accountId, int productId);
    }
}
