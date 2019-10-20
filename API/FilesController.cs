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
    public class FilesController : ControllerBase
    {

        //[HttpPost("UploadFiles")]
        //public async Task<IActionResult> UploadFileAsync(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);

        //    // full path to file in temp location
        //    var filePath = Path.GetTempFileName();

        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        await files[0].CopyToAsync(memoryStream);
        //        user.AvatarImage = memoryStream.ToArray();
        //        await _db.SaveChangesAsync();
        //        await _userManager.UpdateAsync(user);
        //    }

        //    return Redirect("Identity/Account/Manage/PersonalData");
        //    //if (User.Identity.IsAuthenticated)
        //    //{

        //    //    return View();
        //    //}
        //    //else
        //    //{
        //    //    return RedirectToAction("Error");
        //    //}
        //}

        //public async Task<FileContentResult> getImgAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    return user.AvatarImage != null
        //        ? new FileContentResult(user.AvatarImage, "image/jpeg")
        //        : null;
        //}

        //public async Task<FileContentResult> getImgByIdAsync(long id)
        //{
        //    User user = await _userManager.FindByIdAsync(id + "");
        //    return user.AvatarImage != null
        //        ? new FileContentResult(user.AvatarImage, "image/jpeg")
        //        : null;
        //}
    }
}