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
    public class GiftRepository : BaseRepository<Gift>, IGiftRepository
    {
        private readonly GiftDAO _giftDAO;
        public GiftRepository(GiftDAO giftDAO) : base(giftDAO)
        {
            _giftDAO = giftDAO;
        }

        public Task<Gift> AddAsync(Gift entity)
        {
            return _giftDAO.AddAsync(entity);
        }

        public Task<Gift> DeleteAsync(Gift entity)
        {
            return _giftDAO.DeleteAsync(entity);
        }

        public Task<IEnumerable<Gift>> GetAllAsync()
        {
            return _giftDAO.GetAllAsync();
        }

        public Task<Gift> GetByIdAsync(int id)
        {
            return _giftDAO.GetByIdAsync(id);
        }

        public Task<IEnumerable<Gift>> SearchGiftAsync(string? search, int pageIndex, int pageSize)
        {
            return _giftDAO.SearchGiftAsync(search, pageIndex, pageSize);
        }

        /*public Task<Category> GetByStringId(string id)
        {
            throw new NotImplementedException();
        }*/

        public Task<Gift> UpdateAsync(Gift entity)
        {
            return _giftDAO.UpdateAsync(entity);
        }
    }
}
