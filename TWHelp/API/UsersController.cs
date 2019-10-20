using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TWHelp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //public async Task<IActionResult> UpdateAbout(string about)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    user.About = about;
        //    _db.Users.Update(user);
        //    _db.SaveChanges();
        //    return Redirect("~/Identity/Account/Manage/PersonalData");
        //}
    }
}