using BussinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IReportRepository : IBaseRepository<Report>
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<IEnumerable<Report>> SearchReportAsync(string search, int pageIndex, int pageSize);
        Task<Report> GetReportByIdAsync(int id);

    }
}
