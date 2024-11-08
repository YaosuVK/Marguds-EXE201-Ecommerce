using BussinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserVoucherRepository : IBaseRepository<UserVoucher>
    {
        Task<IEnumerable<UserVoucher>> GetAllUserUnusedVouchersAsync(string accountId);
    }
}
