using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Domain;
using Domain.Models.Identity;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWHelp.Models.DTOs.Forum;

namespace TWHelp.Areas.Forum.Pages
{
    public class UploadVideoModel : PageModel
    {
        private UserManager<User> userManager;
        private ApplicationDbContext context;

        public UploadVideoModel(UserManager<User> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        [BindProperty]
        public ForumVideoInputModel InputModel { get; set; }

        public class ForumVideoInputModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Tags { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPostFileUploadAsync(IFormFile file)
        {
            if(file == null)
            {
                return BadRequest("file is incorrect");
            }

            string extension = Path.GetExtension(file.FileName);
            User user = await userManager.GetUserAsync(User);

            if (extension == ".avi" || extension == ".mp4")
            {
                try
                {
                    string fileName = $@"\videos\{user.Email}_{DateTime.Now.ToString("yyyy-MM-ddThh-mm-ss")}_{file.FileName}";

                    using (var fileStream = new FileStream(".\\wwwroot" + fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var forumVideo = new ForumVideo()
                    {
                        UploaderId = user.Id,
                        Name = InputModel.Name,
                        Description = InputModel.Description,
                        TagsString = InputModel.Tags,
                        VideoFilePath = fileName,
                        Created = DateTime.Now,
                    };

                    context.ForumVideos.Add(forumVideo);
                    await context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    return BadRequest($"{ex.ToString()}");
                }
            }
            else
            {
                return BadRequest("not supported type");
            }

            return StatusCode(200);
        }
    }
}
