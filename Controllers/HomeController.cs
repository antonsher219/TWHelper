using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TWHelp.Data;
using TWHelp.Models;

namespace TWHelp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public HomeController(ApplicationDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forum(Topic topic)
        {
            if (ModelState.IsValid)
            {
                topic.Creator = await _userManager.GetUserAsync(User);

                topic.CreatingTime = DateTime.Now;
                _db.Topics.Add(topic);
                
                _db.SaveChanges();
            }

            ViewBag.Topics = _db.Topics
                .Include(top => top.Creator)
                .OrderByDescending(x => x.CreatingTime);
            return View();
        }

        public IActionResult Forum()
        {
            ViewBag.Topics = _db.Topics
                .Include(top => top.Creator)
                .OrderByDescending(x => x.CreatingTime);
            return View();
        }

        public IActionResult CreateTopic()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
