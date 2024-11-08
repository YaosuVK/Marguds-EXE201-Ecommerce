using BussinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ISubcriptionRepository : IBaseRepository<Subscription>
    {
        public Task AddSubcriptionAsync(Subscription subscription);
        public Task<Subscription?> ChangeSubcriptionStatus(int Id, SubcriptionStatus status);
        public Task<IEnumerable<Subscription>> GetSubcriptionsBySubPlan(int planID);
        public Task<Subscription> GetSubcriptionByAccountID(string accountID);
        public Task<IEnumerable<Subscription>> GetSubcriptionsByDateAsync(DateTime startDate);
        public Task<IEnumerable<Subscription>> GetAllAsync();
        public Task UpdateSubcriptionAsync(Subscription subscription);
    }
}
