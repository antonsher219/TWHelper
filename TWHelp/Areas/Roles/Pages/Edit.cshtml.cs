using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWHelp.Models;

namespace TWHelp.Areas.Roles.Pages
{
    public class EditModel : PageModel
    {
        private RoleManager<IdentityRole<long>> _roleManager;
        private UserManager<User> _userManager;
        public ChangeRoleViewModel ChangeRoleViewModel { get; set; }

        public new User User;
        public IList<string> Roles { get; set; }

        public EditModel(RoleManager<IdentityRole<long>> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            ChangeRoleViewModel = new ChangeRoleViewModel();
        }

        public async Task OnGet(long userId)
        {
            ChangeRoleViewModel.AllRoles = _roleManager.Roles.ToList();
            User = await _userManager.FindByIdAsync(userId.ToString());
            Roles = await _userManager.GetRolesAsync(User);
        }

        public async Task<IActionResult> OnPost(long userId, List<string> roles)
        {
            User user = await _userManager.FindByIdAsync(userId.ToString());

            var userRoles = await _userManager.GetRolesAsync(user);
            // получаем все роли
            var allRoles = _roleManager.Roles.ToList();
            // получаем список ролей, которые были добавлены
            var addedRoles = roles.Except(userRoles);
            // получаем роли, которые были удалены
            var removedRoles = userRoles.Except(roles);

            await _userManager.AddToRolesAsync(user, addedRoles);

            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            return RedirectToPage("/Index", "");
        }
    }
}