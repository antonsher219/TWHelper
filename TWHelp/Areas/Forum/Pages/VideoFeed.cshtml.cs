using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace TWHelp.Areas.Forum.Pages
{
    public class VideoFeedModel : PageModel
    {
        private UserManager<User> _userManager;
        private IConfiguration _configuration;

        public VideoFeedModel(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public string WebRoot { get; set; }
        public long UserId { get; set; }

        public async Task OnGet()
        {
            WebRoot = "http://" + HttpContext.Request.Host.ToUriComponent();

            User user = await _userManager.GetUserAsync(User);
            UserId = user.Id;
        }
    }
}
