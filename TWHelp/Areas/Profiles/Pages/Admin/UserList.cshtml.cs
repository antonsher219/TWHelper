using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Roles.Pages
{
    public class UserListModel : PageModel
    {
        private RoleManager<IdentityRole<long>> _roleManager;
        private UserManager<User> _userManager;

        public IEnumerable<User> Users;

        public UserListModel(RoleManager<IdentityRole<long>> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task OnGet(string roleName)
        {
            Users = await _userManager.GetUsersInRoleAsync(roleName);
            
        }
    }
}