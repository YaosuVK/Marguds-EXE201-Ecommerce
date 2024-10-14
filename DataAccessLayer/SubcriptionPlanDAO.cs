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
    public class SubcriptionPlanDAO : BaseDAO<SubcriptionPlan>
    {
        private readonly MargudsContext _context;
        public SubcriptionPlanDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubcriptionPlan>> GetAllAsync()
        {
            return await _context.SubcriptionPlans
            .ToListAsync();
        }
        public async Task<SubcriptionPlan> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<SubcriptionPlan>()
               .SingleOrDefaultAsync(c => c.PlanID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }

    }
}
