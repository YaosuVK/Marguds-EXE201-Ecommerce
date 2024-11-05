using BussinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.Shipping;
using Service.RequestAndResponse.Request.VnPayModel;
using Service.Service;
using System.Globalization;
using System.Text.Json;

namespace Marguds_EXE201_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcriptionController : ControllerBase
    {
        private readonly ISubcriptionService _subService;
        private readonly IVnPayService _vnPayService;
        private readonly IConfiguration _configuration;
        private readonly ISubcriptionPlanService _subPlanService;

        public SubcriptionController(ISubcriptionService subService, IVnPayService vnPayService, ISubcriptionPlanService subPlanService,
            IConfiguration configuration)
        {
            _subService = subService;
            _vnPayService = vnPayService;
            _configuration = configuration;
            _subPlanService = subPlanService;
        }

        [HttpGet("get-all-Subcriptions")]
        public async Task<IEnumerable<Subscription>> GetAllSubcriptionAsync() 
        {
            return await _subService.GetAllAsync();
        }

        [HttpGet("get-all-Subcription-by-id/{accountId}")]
        public async Task<Subscription> GetSubcriptionByAccountID(string accountID)
        {
            return await _subService.GetSubcriptionByAccountID(accountID);
        }

        [HttpGet("get-subcription-by-id/{planID}")]
        public async Task<IEnumerable<Subscription>> GetSubcriptionsBySubPlan(int planID)
        {
            return await _subService.GetSubcriptionsBySubPlan(planID);
        }

        [HttpPut("update-Subcription-status")]
        public async Task<Subscription?> ChangeSubcriptionStatus(int Id, SubcriptionStatus status)
        {
            return await _subService.ChangeSubcriptionStatus(Id, status);
        }

        

        [HttpPost("createSubcription")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<string> CreateSubcription(string accountId, int planID)
        {
            /*var amount = await _subPlanService.GetSubscriptionPlanByIdFromBase(planID);*/

            var subcription = await _subService.RegisterMember(accountId, planID);
            var orderId = subcription.SubcriptionID;
            // create payment vnpay
            var vnPayModel = new VnPayRequestModel
            {
                Amount = subcription.SubscriptionPlans.Price,
                CreatedDate = DateTime.Now,
                Description = $"{subcription.Account.Name} has registered {subcription.SubscriptionPlans.PlanName}",
                FullName = subcription.Account.Name,
                OrderId = orderId,
                OrderInfor = JsonSerializer.Serialize(new { AccountId = accountId, subcription.SubscriptionPlans.PlanName})
            };
            return _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel);
        }

        [HttpGet("vnpay-return")]
        public async Task<IActionResult> HandleVnPayReturn([FromQuery] VnPayReturnModel model)
        {
            if (model.Vnp_TransactionStatus != "00") return BadRequest();
            var transaction = new Transaction
            {
                Amount = model.Vnp_Amount,
                BankCode = model.Vnp_BankCode,
                BankTranNo = model.Vnp_BankTranNo,
                TransactionType = model.Vnp_CardType,
                OrderInfo = model.Vnp_OrderInfo,
                PayDate = DateTime.ParseExact((string)model.Vnp_PayDate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                ResponseCode = model.Vnp_ResponseCode,
                TmnCode = model.Vnp_TmnCode,
                TransactionNo = model.Vnp_TransactionNo,
                TransactionStatus = model.Vnp_TransactionStatus,
                TxnRef = model.Vnp_TxnRef,
                SecureHash = model.Vnp_SecureHash,
                ResponseId = model.Vnp_TransactionNo,
                Message = model.Vnp_ResponseCode
            };
            var orderId = Convert.ToInt32(model.Vnp_OrderInfo);
            await _subService.CreateSubcription(orderId, transaction);
            return Redirect($"{_configuration["VnPay:UrlReturnPayment"]}/{orderId}");
        }
    }
}
