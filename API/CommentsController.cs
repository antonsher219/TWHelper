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
    public class CommentsController : ControllerBase
    {
        //public async Task<IActionResult> AddCommentAsync(string id, string content)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        Comment comment = new Comment();
        //        comment.Creator = await _userManager.GetUserAsync(User);
        //        comment.CreateTime = DateTime.Now;
        //        comment.ParentTopic = _db.Topics.First(top => top.Id == Convert.ToInt32(id));
        //        comment.Content = content;
        //        _db.Comments.Add(comment);
        //        _db.SaveChanges();
        //        return RedirectToAction("TopicView", "Home", new { id = id });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}

        //public async Task<IActionResult> DelCommentAsync(string id)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var comment = _db.Comments.Include(com => com.ParentTopic).Include(com => com.Creator).First(com => com.Id == Convert.ToInt32(id));
        //        comment.IsDeleted = true;
        //        _db.Comments.Update(comment);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction("TopicView", "Home", new
        //        {
        //            id = comment.ParentTopic.Id
        //        });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}
    }
}