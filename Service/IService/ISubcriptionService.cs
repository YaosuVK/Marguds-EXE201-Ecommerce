using BussinessObject.Model;
using Service.RequestAndResponse.Request.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ISubcriptionService
    {
        public Task<Subscription> RegisterMember(string accountId, int planID);
        public Task<Subscription> CreateSubcription(int subId, Transaction transaction);
        public Task<Subscription?> ChangeSubcriptionStatus(int Id, SubcriptionStatus status);
        public Task<IEnumerable<Subscription>> GetSubcriptionsBySubPlan(int planID);
        public Task<Subscription> GetSubcriptionByAccountID(string accountID);
        public Task<IEnumerable<Subscription>> GetSubcriptionsByDateAsync(DateTime startDate);
        public Task<IEnumerable<Subscription>> GetAllAsync();
    }
}
