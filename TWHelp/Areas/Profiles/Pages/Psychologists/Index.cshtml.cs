using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace TWHelp.Areas.Profiles.Pages.Psychologists
{
    public class IndexModel : PageModel
    {
        private UserManager<User> _userManager;
        private IConfiguration _configuration;

        public IndexModel(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public string WebRoot { get; set; }
        public bool IsUserPsycho { get; set; }

        public async Task OnGet()
        {
            //WebRoot = "http://" + HttpContext.Request.Host.ToUriComponent();
            WebRoot = _configuration["ConnectionStrings:Docker:PythonModel"];

            User user = await _userManager.GetUserAsync(User);
            IsUserPsycho = user.IsPsychologist;
        }
    }
}
