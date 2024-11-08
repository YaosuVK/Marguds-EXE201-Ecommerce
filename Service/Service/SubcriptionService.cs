using AutoMapper;
using BussinessObject.Model;
using MailKit.Search;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class SubcriptionService : ISubcriptionService
    {
        private readonly IMapper _mapper;
        private readonly ISubcriptionRepository _subRepository;
        private readonly ISubcriptionPlanRepository _subPlanRepository;

        public SubcriptionService(IMapper mapper, ISubcriptionRepository subRepository, ISubcriptionPlanRepository subcriptionPlanRepository)
        {
            _mapper = mapper;
            _subRepository = subRepository;
            _subPlanRepository = subcriptionPlanRepository;
        }

        public async Task<Subscription?> ChangeSubcriptionStatus(int Id, SubcriptionStatus status)
        {
            return await _subRepository.ChangeSubcriptionStatus(Id, status);
        }

        public async Task<Subscription> CreateSubcription(int subId, Transaction transaction)
        {
            var subcription = await _subRepository.GetByIdAsync(subId);
            if (subcription == null)
            {
                throw new Exception("Order not found");
            }
            subcription.Transaction = transaction;
            subcription.Status = SubcriptionStatus.Active;
            await _subRepository.UpdateAsync(subcription);
            return subcription;
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _subRepository.GetAllAsync();
        }

        public async Task<Subscription> GetSubcriptionByAccountID(string accountID)
        {
            return await _subRepository.GetSubcriptionByAccountID(accountID);
        }

        public async Task<IEnumerable<Subscription>> GetSubcriptionsByDateAsync(DateTime startDate)
        {
            return await _subRepository.GetSubcriptionsByDateAsync(startDate);
        }

        public async Task<IEnumerable<Subscription>> GetSubcriptionsBySubPlan(int planID)
        {
            return await _subRepository.GetSubcriptionsBySubPlan(planID);
        }

        public async Task<Subscription> RegisterMember(string accountId, int planID)
        {
            var package = await _subPlanRepository.GetByIdAsync(planID);
            
            if (package == null)
            {
                throw new Exception("SubcriptionPlan's Package is empty");
            }

            var subcription = new Subscription
            {
                AccountID = accountId,
                PlanID = planID,
                StartedAt = DateTime.Now,
                EndedAt = DateTime.Now.AddDays(package.Duration),
                Status = SubcriptionStatus.Deactive
            };

            await _subRepository.AddSubcriptionAsync(subcription);
            return subcription;
        }
    }
}
