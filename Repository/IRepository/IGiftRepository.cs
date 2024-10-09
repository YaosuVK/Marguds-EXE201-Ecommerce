using BussinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IGiftRepository : IBaseRepository<Gift>
    {
        Task<IEnumerable<Gift>> SearchGiftAsync(string? search, int pageIndex, int pageSize);
    }
}
