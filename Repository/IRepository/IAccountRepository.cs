using BussinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<(int totalAccount, int staffsAccount, int managersAccount, int customersAccount)> GetTotalAccount();

    }
}
