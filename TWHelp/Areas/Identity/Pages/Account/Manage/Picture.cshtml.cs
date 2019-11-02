using Domain.Models.Identity;

using System;
using System.Threading.Tasks;
using System.IO;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace TWHelp.Areas.Identity.Pages.Account.Manage
{
    public class PictureModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public PictureModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string ConvertedPhoto { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            if(user == null)
            {
                return BadRequest("server error. user is null");
            }

            //if avatar pic is null then use dafault pic
            ConvertedPhoto = user.AvatarImage == null ? "/img/user-profile.png" : $"data:image/gif;base64,{Convert.ToBase64String(user.AvatarImage)}";

            ViewData["IsPsychologist"] = user.IsPsychologist.ToString();
            ViewData["IsAccountActivated"] = user.IsAccountActivated.ToString();

            return Page();
        }

        public async Task<IActionResult> OnPostPhotoUpdateAsync(IFormFile photo)
        {
            if (photo == null)
            {
                return BadRequest();
            }

            string extension = Path.GetExtension(photo.FileName);

            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return NotFound("user not found. server error");
                }

                using (var stream = new MemoryStream())
                {
                    await photo.CopyToAsync(stream);
                    user.AvatarImage = stream.ToArray();

                    await _userManager.UpdateAsync(user);
                }

                string convertedPhoto = Convert.ToBase64String(user.AvatarImage);
                ConvertedPhoto = $"data:image/gif;base64,{convertedPhoto}";

                return Page();
            }

            return BadRequest("format not supported");
        }

        public async Task<IActionResult> OnPostPhotoDeleteAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("user not found. server error");
            }

            user.AvatarImage = null;

            await _userManager.UpdateAsync(user);

            return Page();
        }
    }
}
