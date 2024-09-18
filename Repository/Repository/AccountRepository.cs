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
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        private readonly AccountDAO _accountDao;

        public AccountRepository(AccountDAO accountDao) : base(accountDao)
        {
            _accountDao = accountDao;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountDao.GetAllAsync();
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _accountDao.GetByIdAsync(id);
        }

        public async Task<Account> GetByStringIdAsync(string id)
        {
            return await _accountDao.GetByStringIdAsync(id);
        }

        public async Task<Account> AddAsync(Account entity)
        {
            return await _accountDao.AddAsync(entity);
        }

        public async Task<Account> UpdateAsync(Account entity)
        {
            return await _accountDao.UpdateAsync(entity);
        }

        public async Task<Account> DeleteAsync(Account entity)
        {
            return await _accountDao.DeleteAsync(entity);
        }

        public async Task<(int totalAccount, int staffsAccount, int managersAccount, int customersAccount)> GetTotalAccount()
        {
            return await _accountDao.GetTotalAccount();
        }
    }
}
