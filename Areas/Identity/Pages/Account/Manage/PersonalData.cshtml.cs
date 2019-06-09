using System.Threading.Tasks;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TWHelp.Models;

namespace TWHelp.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        public IFormFile AvatarImage { get; set; }
        private readonly UserManager<User> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;

        public PersonalDataModel(
            UserManager<User> userManager,
            ILogger<PersonalDataModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            ViewData["UserName"] = user.Nickname;
            ViewData["Email"] = user.Email;
            ViewData["Phone"] = user.PhoneNumber;
            ViewData["Age"] = user.Age;
            ViewData["Avatar"] = user.AvatarImage;
            ViewData["About"] = user.About;
            //using (var reader = new DatabaseReader("C:\\Users\\Sher\\source\\repos\\TWHelp\\TWHelp\\wwwroot\\GeoLite2-City.mmdb"))
            //{
            //    var ipAddress = HttpContext.Connection.RemoteIpAddress;
            //    // Get the city from the IP Address
            //    var city = reader.City(ipAddress);
            //}
            return Page();
        }
    }
}