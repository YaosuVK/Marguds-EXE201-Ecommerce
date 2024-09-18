using BussinessObject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Report;
using Service.RequestAndResponse.Response.Report;

namespace Marguds_EXE201_Ecommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;
    private readonly IFileService _fileService;
    private readonly IOrderService _orderService;
    public ReportController(IReportService reportService, IFileService fileService, IOrderService orderService)
    {
        _reportService = reportService;
        _fileService = fileService;
        _orderService = orderService;
    }

    /*[Authorize(Roles = "Staff")]*/
    [HttpGet]
    [Route("get-all-reports")]
    public async Task<ActionResult<BaseResponse<IEnumerable<ReportResponse>>>> GetAllReports()
    {
        var reports = await _reportService.GetAllReportFromBase();
        return Ok(reports);
    }

    /*[Authorize(Roles = "Staff")]*/
    [HttpGet]
    [Route("/search")]
    public async Task<ActionResult<BaseResponse<IEnumerable<ReportResponse>>>> GetSearchReportFromBase(string search, int pageIndex, int pageSize)
    {
        return await _reportService.GetSearchReportFromBase(search, pageIndex, pageSize);
    }

    /*[Authorize(Roles = "Staff, Customer")]*/
    [HttpGet]
    [Route("get-report-by-id/{id}")]
    public async Task<ActionResult<BaseResponse<ReportResponse>>> GetReportById(int id)
    {
        return await _reportService.GetReportByIdFromBase(id);
    }

    /*[Authorize(Roles = "Customer")]*/
    [HttpPost]
    [Route("create-report")]
    public async Task<ActionResult<BaseResponse<ReportResponse>>> CreateReportFromBase([FromForm] CreateReportRequest request)
    {
        string createdImageName = null;

        if (request.ImageFile != null && request.ImageFile.Length > 0)
        {
            createdImageName = _fileService.ConvertToString(request.ImageFile);
        }

        var report = new ReportRequest
        {
            CreateAt = request.CreateAt,
            UpdateAt = request.UpdateAt,
            ReportText = request.ReportText,
            ResponseText = request.ResponseText,
            AccountID = request.AccountID,
            ProductID = request.ProductID,
            OrderID = request.OrderID,
            Image = createdImageName,
        };

        var result = await _reportService.CreateReportFromBase(report);
        return result;
    }

   /* [Authorize(Roles = "Customer, Staff")]*/
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<BaseResponse<Report>>> DeleteReport(int id)
    {
        var existingProduct = await _reportService.GetReportByIdFromBase(id);
        if (existingProduct == null)
        {
            return NotFound(new { message = "Report not found" });
        }

        var success = await _reportService.DeleteReport(id);

        if (success == null)
        {
            return BadRequest(new { message = "Failed to delete report" });
        }

        return Ok(new { message = "Delete Report Successful" });
    }

   /* [Authorize(Roles = "Customer")]*/
    [HttpPut]
    [Route("update-report")]
    public async Task<ActionResult<BaseResponse<ReportRequestUpdate>>> UpdateReportFromBase(int id,
        [FromForm] UpdateReportRequest report)
    {
        string createdImageName = null;

        if (report.ImageFile != null && report.ImageFile.Length > 0)
        {
            createdImageName = _fileService.ConvertToString(report.ImageFile);
        }
        var reportResult = new ReportRequestUpdate
        {
            ReportText = report.ReportText,
            ResponseText = report.ResponseText,
            Image = createdImageName,
            UpdateAt = report.UpdateAt
        };
        return await _reportService.UpdateReportFromBase(id, reportResult);
    }
}

