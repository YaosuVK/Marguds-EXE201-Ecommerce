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
    public class UserVoucherRepository : BaseRepository<UserVoucher>, IUserVoucherRepository
    {
        private readonly UserVoucherDAO _userVoucherDao;
        public UserVoucherRepository(UserVoucherDAO userVoucherDao) : base(userVoucherDao)
        {
            _userVoucherDao = userVoucherDao;
        }
        public async Task<IEnumerable<UserVoucher>> GetAllUserUnusedVouchersAsync(string accountId)
        {
            // Assume _userVoucherDao is set up for database access
            var userVouchers = await _userVoucherDao.GetAllAsync(); // Assuming this retrieves all UserVouchers

            return userVouchers.Where(uv => uv.AccountID == accountId && uv.Status == true).ToList();
        }
    }
}
