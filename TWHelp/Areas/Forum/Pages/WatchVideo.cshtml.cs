using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWHelp.Models.DTOs.Forum;

namespace TWHelp.Areas.Forum.Pages
{
    public class WatchVideoModel : PageModel
    {
        private ApplicationDbContext context;

        public WatchVideoModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ForumVideoDTO Input { get; set; }

        public class ForumVideoDTO
        {
            public string Path { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
            public string Date { get; set; }
        }

        public void OnGet(int id)
        {
            var video = context.ForumVideos
                .FirstOrDefault(v => v.Id == id);

            if (video != null)
            {
                var user = context.Users.First(u => u.Id == video.UploaderId);

                var input = new ForumVideoDTO()
                {
                    Path = "..\\" + video.VideoFilePath,
                    Name = video.Name,
                    Author = user.Email,
                    Date = video.Created.ToString("yyyy-MM-dd"),
                };

                Input = input;
            }
        }
    }
}
