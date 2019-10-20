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
    public class TestsController : ControllerBase
    {

        //public IActionResult Tests()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        ViewBag.Tests = _db.Tests.Include(test => test.Creator);
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}

        //public IActionResult TestView(string id)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var test = _db.Tests.Include(_test => _test.Creator).First(t_id => t_id.Id.ToString().Equals(id));
        //        ViewBag.Test = test.TestUrl;

        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}


        //[Authorize(Roles = "admin,specialist")]
        //public async Task<IActionResult> CreateTestAsync(Test test)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        test.Creator = await _userManager.GetUserAsync(User);
        //        _db.Tests.Add(test);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction("Tests");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}

    }
}