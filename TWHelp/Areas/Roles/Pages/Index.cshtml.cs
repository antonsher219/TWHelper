using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWHelp.Controllers;

namespace TWHelp.Areas.Roles.Pages
{
    [Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        public Dictionary<IdentityRole<long>, int> RolesDict;
        private RoleManager<IdentityRole<long>> _roleManager;

        private UserManager<User> _userManager;

        public IndexModel(RoleManager<IdentityRole<long>> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            RolesDict = new Dictionary<IdentityRole<long>, int>();
        }

        public void OnGet()
        {
            RolesDict.Clear();
            foreach (var role in _roleManager.Roles)
            {
                RolesDict.Add(role, _userManager.GetUsersInRoleAsync(role.ToString()).Result.Count);
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(long roleId)
        {
            RolesController rolesController = new RolesController(_roleManager, _userManager);
            IActionResult result = await rolesController.DeleteRole(roleId.ToString()); //TODO: role name, not an id ?
            RolesDict.Clear();

            foreach (var role in _roleManager.Roles)
            {
                RolesDict.Add(role, _userManager.GetUsersInRoleAsync(role.ToString()).Result.Count);
            }
            return Page();
        }
    }
}
