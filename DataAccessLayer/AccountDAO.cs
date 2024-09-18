using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountDAO : BaseDAO<Account>
    {
        private readonly MargudsContext _context;
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountDAO(MargudsContext context, UserManager<Account> userManager,
            RoleManager<IdentityRole> roleManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<(int totalAccount, int staffsAccount, int managersAccount, int customersAccount)> GetTotalAccount()
        {
            var customerRole = await _roleManager.FindByNameAsync("Customer");
            var customersCount = await _userManager.GetUsersInRoleAsync(customerRole.Name);

            var staffRole = await _roleManager.FindByNameAsync("Staff");
            var staffsCount = await _userManager.GetUsersInRoleAsync(staffRole.Name);

            var managerRole = await _roleManager.FindByNameAsync("Manager");
            var managersCount = await _userManager.GetUsersInRoleAsync(managerRole.Name);

            int totalAccountsCount = customersCount.Count + staffsCount.Count + managersCount.Count;
            int staffsAccount = staffsCount.Count;
            int managersAccount = managersCount.Count;
            int customersAccount = customersCount.Count;

            return (totalAccountsCount, staffsAccount, managersAccount, customersAccount);
        }
    }
}
