using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Profiles.Pages.Users
{
    public class IndexModel : PageModel
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole<long>> _roleManager;

        public IList<User> Users;

        public IndexModel(UserManager<User> userManager, RoleManager<IdentityRole<long>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task OnGetAsync()
        {
            Users = await _userManager.GetUsersInRoleAsync("user");
        }
    }
}