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

    }
}
