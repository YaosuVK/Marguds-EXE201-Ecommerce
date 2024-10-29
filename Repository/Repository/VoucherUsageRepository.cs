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
    public class VoucherUsageRepository : BaseRepository<VoucherUsage>, IVoucherUsageRepository
    {
        private readonly VoucherUsageDAO _voucherUsageDao;
        public VoucherUsageRepository(VoucherUsageDAO voucherUsageDao) : base(voucherUsageDao)
        {
            _voucherUsageDao = voucherUsageDao;
        }

    }
}
