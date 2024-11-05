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
    public class SubcriptionRepository : BaseRepository<Subscription>, ISubcriptionRepository
    {
        private readonly SubcriptionDAO _subDAO;
        public SubcriptionRepository(SubcriptionDAO subDAO) : base(subDAO)
        {
            _subDAO= subDAO;
        }

        public async Task AddSubcriptionAsync(Subscription subscription)
        {
             await _subDAO.AddSubcriptionAsync(subscription);
        }

        public async Task<Subscription?> ChangeSubcriptionStatus(int Id, SubcriptionStatus status)
        {
            return await _subDAO.ChangeSubcriptionStatus(Id, status);
        }

        public async Task<Subscription> GetSubcriptionByAccountID(string accountID)
        {
            return await _subDAO.GetByStringIdAsync(accountID);
        }

        public async Task<IEnumerable<Subscription>> GetSubcriptionsByDateAsync(DateTime startDate)
        {
            return await _subDAO.GetSubcriptionsByDateAsync(startDate);
        }

        public async Task<IEnumerable<Subscription>> GetSubcriptionsBySubPlan(int planID)
        {
            return await _subDAO.GetSubcriptionsBySubPlan(planID);
        }

        public async Task UpdateSubcriptionAsync(Subscription subscription)
        {
           await _subDAO.UpdateAsync(subscription);
        }
    }
}
