using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Forum.Pages
{
    public class UploadVideoModel : PageModel
    {
        UserManager<User> userManager;

        public UploadVideoModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
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
                    string fileName = $@".\wwwroot\videos\{user.Email}_{DateTime.Now.ToString("yyyy-MM-ddThh-mm-ss")}_{file.FileName}";

                    using (var fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
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
