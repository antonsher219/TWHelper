using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWHelp.Controllers;

namespace TWHelp.Areas.Roles.Pages
{
    public class CreateModel : PageModel
    {
        private RoleManager<IdentityRole<long>> _roleManager;
        private UserManager<User> _userManager;

        [BindProperty]
        public CreateRoleModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public class CreateRoleModel
        {
            [Required]
            [Display(Name = "Role name")]
            public string RoleName { get; set; }

        }

        public CreateModel(RoleManager<IdentityRole<long>> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            IActionResult result = await CreateRole();
            if (result is OkObjectResult)
            {
                StatusMessage = "Role created";
                return RedirectToPage("/Index");
            }
            if (!String.IsNullOrEmpty(Input.RoleName))
            {
                StatusMessage = "Role with the same name exists";
            }
            return Page();
        }

        public async Task<IActionResult> CreateRole()
        {
            RolesController rolesController = new RolesController(_roleManager, _userManager);
            return await rolesController.CreateNewRole(Input.RoleName);
        }
    }
}