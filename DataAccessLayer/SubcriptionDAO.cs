using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SubcriptionDAO : BaseDAO<Subscription>
    {
        private readonly MargudsContext _context;
        //
        public SubcriptionDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _context.Subscriptions
                .Include(c => c.SubscriptionPlans)
                .Include(s => s.Account)
                .Include(s => s.Transaction)
                .ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetSubcriptionsByDateAsync(DateTime startDate)
        {
            return await _context.Subscriptions
                .Include(o => o.Account)
                .Include(o => o.Transaction)
                .Include( o => o.SubscriptionPlans)
                .Where(o => o.StartedAt.Date == startDate.Date)
                .ToListAsync();
        }

        public async Task<Subscription> GetSubcriptionByAccountID(string accountID)
        {
            var entity = await _context.Set<Subscription>()
              .Include(c => c.SubscriptionPlans)
              .Include(s => s.Transaction)
              .SingleOrDefaultAsync(c => c.AccountID == accountID);
            
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {accountID} not found");
            }

            return entity;
        }

        public async Task<IEnumerable<Subscription>> GetSubcriptionsBySubPlan(int planID)
        {
            var entity = await _context.Subscriptions
              .Include(c => c.SubscriptionPlans)
              .Include(s => s.Transaction)
              .Where(s => s.PlanID == planID).ToListAsync();

            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {planID} not found");
            }

            return entity;
        }

        public async Task AddSubcriptionAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        /*public async Task<Subscription?> UpdateSubcriptionAsync(int subId, Subscription subscription)
        {

            var existSubcription = await _context.Subscriptions.FindAsync(subId);
            if (existSubcription != null)
            {
                existSubcription.ReportID = order.ReportID;
            }
            await _context.SaveChangesAsync();
            return existOrder;
        }*/

        public async Task<Subscription?> ChangeSubcriptionStatus(int Id, SubcriptionStatus status)
        {
            var subscription = await _context.Subscriptions.FindAsync(Id);
            if (subscription != null)
            {
                subscription.Status= status;
                await _context.SaveChangesAsync();
            }

            return await _context.Subscriptions.FindAsync(Id);
        }

       
    }
}
