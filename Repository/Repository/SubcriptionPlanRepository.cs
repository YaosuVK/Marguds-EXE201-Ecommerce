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
    public class SubcriptionPlanRepository : BaseRepository<SubcriptionPlan>, ISubcriptionPlanRepository
    {
        private readonly SubcriptionPlanDAO _planDAO;
        public SubcriptionPlanRepository(SubcriptionPlanDAO planDAO) : base(planDAO)
        {
            _planDAO = planDAO;
        }

        public Task<SubcriptionPlan> AddAsync(SubcriptionPlan entity)
        {
            return _planDAO.AddAsync(entity);
        }

        public Task<SubcriptionPlan> DeleteAsync(SubcriptionPlan entity)
        {
            return _planDAO.DeleteAsync(entity);
        }

        public Task<IEnumerable<SubcriptionPlan>> GetAllAsync()
        {
            return _planDAO.GetAllAsync();
        }

        public Task<SubcriptionPlan> GetByIdAsync(int id)
        {
            return _planDAO.GetByIdAsync(id);
        }


        public Task<SubcriptionPlan> UpdateAsync(SubcriptionPlan entity)
        {
            return _planDAO.UpdateAsync(entity);
        }

    }
}
