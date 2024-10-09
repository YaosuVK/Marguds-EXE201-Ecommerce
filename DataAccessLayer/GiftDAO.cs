using BussinessObject.IdentityModel;
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
    public class GiftDAO : BaseDAO<Gift>
    {
        private readonly MargudsContext _context;
        public GiftDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gift>> GetAllAsync()
        {
            return await _context.Gifts
            .ToListAsync();
        }

        public async Task<Gift> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<Gift>()
               .SingleOrDefaultAsync(c => c.GiftID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }

        public async Task<IEnumerable<Gift>> SearchGiftAsync(string? search, int pageIndex, int pageSize)
        {
            IQueryable<Gift> searchGifts = _context.Gifts;

            if (!string.IsNullOrEmpty(search))
            {
                searchGifts = searchGifts
                            .Where(c => c.GiftName.ToLower().Contains(search.ToLower()));
            }

            var result = PaginatedList<Gift>.Create(searchGifts, pageIndex, pageSize).ToList();
            return result;
        }
    }
}
