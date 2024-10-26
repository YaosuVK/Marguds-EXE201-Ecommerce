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
    public class VoucherTemplateRepository : BaseRepository<VoucherTemplate>, IVoucherTemplateRepository
    {
        private readonly VoucherTemplateDAO _voucherTemplateDao;
        public VoucherTemplateRepository(VoucherTemplateDAO voucherTemplateDao) : base(voucherTemplateDao)
        {
            _voucherTemplateDao = voucherTemplateDao;
        }

    }
}
