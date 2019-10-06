using Domain.Models.Domain;
using Domain.Models.Identity;
using Infrastructure;
using TWHelp.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TWHelp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;

        public HomeController(ApplicationDbContext db, UserManager<User> userManager, RoleManager<IdentityRole<long>> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
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


        public async Task<IActionResult> Specialists(string roleName)
        {

            var role = await _roleManager.Roles.SingleAsync(r => r.Name == roleName);
            ViewBag.Spec = _db.Users.Where(u => _db.UserRoles.Where(ur => ur.RoleId == role.Id && u.Id == ur.UserId).Select(ur => ur.UserId).Contains(u.Id));
            
            return View();
        }

        public async Task<IActionResult> UpdateAbout( string about)
        {
            var user = await _userManager.GetUserAsync(User);
            user.About = about;
            _db.Users.Update(user);
            _db.SaveChanges();
            return Redirect("~/Identity/Account/Manage/PersonalData");
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

        public async Task<IActionResult> Waiting(string role)
        {
            User user = await _userManager.GetUserAsync(User);
            List<string> roles = new List<string> { role };

            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                await _userManager.AddToRolesAsync(user, roles);
                await _db.SaveChangesAsync();

                return View();
            }

            return NotFound();
        }


        public async Task<IActionResult> Analyze(string name)
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
            ViewData["Chart"] = name + "piechart.png";
            ViewData["Activity"] = name + "activity.png";
            return View();
        }

        public async Task<IActionResult> DeleteTopicAsync(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var topic = _db.Topics.First(top => top.Id == Convert.ToInt32(id));
                _db.Topics.Attach(topic);
                _db.Topics.Remove(topic);
                await _db.SaveChangesAsync();
                return RedirectToAction("Forum");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public async Task<IActionResult> SaveChangesAsync(string id, string theme, string content)
        {
            if (User.Identity.IsAuthenticated)
            {
                var topic = _db.Topics.First(top => top.Id == Convert.ToInt32(id));
                topic.Theme = theme;
                topic.Content = content;
                _db.Topics.Update(topic);
                await _db.SaveChangesAsync();
                return RedirectToAction("Forum");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }


        [Authorize(Roles = "admin,specialist")]
        public async Task<IActionResult> CreateTestAsync(Test test)
        {
            if (User.Identity.IsAuthenticated)
            {
                test.Creator = await _userManager.GetUserAsync(User);
                _db.Tests.Add(test);
                await _db.SaveChangesAsync();
                return RedirectToAction("Tests");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [Authorize(Roles = "admin,specialist")]
        public IActionResult CreateTest()
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
                ViewBag.Tests = _db.Tests.Include(test => test.Creator);
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        public IActionResult TopicView(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var topic = _db.Topics.Include(top => top.Creator).First(t_id => t_id.Id.ToString().Equals(id));
                ViewBag.Topic = topic;
                var comments = _db.Comments.Include(com => com.Creator).Where(com => com.Top.Id == topic.Id);
                if (_db.Comments.Count() > 0)
                {
                    ViewBag.Comments = _db.Comments.Include(com => com.Creator).Where(com => com.Top.Id == topic.Id);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult TestView(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var test = _db.Tests.Include(_test => _test.Creator).First(t_id => t_id.Id.ToString().Equals(id));
                ViewBag.Test = test.TestUrl;
                
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }


        public async Task<IActionResult> AddCommentAsync(string id, string content)
        {
            if (User.Identity.IsAuthenticated)
            {
                Comment comment = new Comment();
                comment.Creator = await _userManager.GetUserAsync(User);
                comment.CreateTime = DateTime.Now;
                comment.Top = _db.Topics.First(top => top.Id == Convert.ToInt32(id));
                comment.Content = content;
                _db.Comments.Add(comment);
                _db.SaveChanges();
                return RedirectToAction("TopicView", "Home", new { id = id });
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> DelCommentAsync(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var comment = _db.Comments.Include(com => com.Top).Include(com =>com.Creator).First(com => com.Id == Convert.ToInt32(id));
                _db.Comments.Attach(comment);
                _db.Comments.Remove(comment);
                await _db.SaveChangesAsync();
                return RedirectToAction("TopicView", "Home", new { id = comment.Top.Id });
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
