using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Tests()
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

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFileAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            using (var memoryStream = new MemoryStream())
            {
                var user = await _userManager.GetUserAsync(User);
                await files[0].CopyToAsync(memoryStream);
                user.AvatarImage = memoryStream.ToArray();
                await _db.SaveChangesAsync();
                await _userManager.UpdateAsync(user);
            }

            return Redirect("Identity/Account/Manage/PersonalData");
            //if (User.Identity.IsAuthenticated)
            //{

            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Error");
            //}
        }

        public async Task<FileContentResult> getImgAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            return user.AvatarImage != null
                ? new FileContentResult(user.AvatarImage, "image/jpeg")
                : null;
        }

        public async Task<FileContentResult> getImgByIdAsync(long id)
        {
            User user = await _userManager.FindByIdAsync(id + "");
            return user.AvatarImage != null
                ? new FileContentResult(user.AvatarImage, "image/jpeg")
                : null;
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
