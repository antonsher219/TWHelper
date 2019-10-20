using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Profiles.Pages.Psychologists
{
    public class IndexModel : PageModel
    {
        private UserManager<User> _userManager;

        public IndexModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public string WebRoot { get; set; }
        public bool IsUserPsycho { get; set; }

        public async Task OnGet()
        {
            WebRoot = HttpContext.Request.Host.ToUriComponent();

            User user = await _userManager.GetUserAsync(User);
            IsUserPsycho = user.IsPsychologist;
        }
    }
}
