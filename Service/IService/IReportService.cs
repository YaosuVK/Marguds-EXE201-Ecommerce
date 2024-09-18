using BussinessObject.Model;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Report;
using Service.RequestAndResponse.Response.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IReportService
    {
        Task<BaseResponse<IEnumerable<ReportResponse>>> GetAllReportFromBase();
        Task<BaseResponse<ReportResponse>> GetReportByIdFromBase(int id);
        Task<BaseResponse<ReportResponse>> CreateReportFromBase(ReportRequest request);
        Task<BaseResponse<ReportRequestUpdate>> UpdateReportFromBase(int id, ReportRequestUpdate report);
        Task<Report> DeleteReport(int id);
        Task<BaseResponse<IEnumerable<ReportResponse>>> GetSearchReportFromBase(string search, int pageIndex, int pageSize);
    }
}
