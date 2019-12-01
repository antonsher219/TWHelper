using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Domain;
using Domain.Models.Identity;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TWHelp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public ForumController(ApplicationDbContext context, UserManager<User> manager)
        {
            _context = context;
            _userManager = manager;
        }


        //public IActionResult TopicView(string id)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var topic = _db.Topics.Include(top => top.Creator).First(t_id => t_id.Id.ToString().Equals(id));
        //        ViewBag.Topic = topic;
        //        var comments = _db.Comments.Include(com => com.Creator).Where(com => com.Top.Id == topic.Id);
        //        if (_db.Comments.Count() > 0)
        //        {
        //            ViewBag.Comments = _db.Comments.Include(com => com.Creator).Where(com => com.Top.Id == topic.Id);
        //        }
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}

        //// GET: api/topic/all
        //[HttpGet("all")]
        //public async Task<IActionResult> GetAllTopics()
        //{
        //    //List<Topic> topics = await _context.Topics
        //    //   .Include(top => top.Creator)
        //    //   .OrderByDescending(x => x.CreatingTime)
        //    //   .ToListAsync();

        //    //return Ok(topics);

        //    return Ok();
        //}

        //// POST: api/topic/create/{topic}
        //[HttpPost("create/{topic}")]
        //public async Task<IActionResult> CreateTopic([FromBody] Topic topic)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        topic.Creator = await _userManager.GetUserAsync(User);
        //        topic.Created = DateTime.Now;

        //        _context.Topics.Add(topic);
        //        _context.SaveChanges();

        //        return Ok();
        //    }

        //    return BadRequest();
        //}

        //// PUT: api/topics/update/{id}/{topic}
        //[HttpPut("update/{id}/{topic}")]
        //public async Task<ActionResult<Topic>> UpdateTopic(int id, [FromBody] Topic topic)
        //{
        //    Topic existedTopic = await _context.Topics
        //        .FirstOrDefaultAsync(top => top.Id == id);

        //    if (topic == null || existedTopic == null)
        //    {
        //        return BadRequest();
        //    }

        //    existedTopic.Content = topic.Content;
        //    existedTopic.Created = topic.Created;
        //    existedTopic.Creator = topic.Creator;
        //    existedTopic.Header = topic.Header;

        //    await _context.SaveChangesAsync();

        //    return Ok(topic);
        //}

        //// DELETE: api/topics/delete/{id}
        //[HttpDelete("delete/{id}")]
        //public async Task<ActionResult<Topic>> Delete(int id)
        //{
        //    Topic topic = await _context.Topics
        //        .FirstOrDefaultAsync(top => top.Id == id);

        //    if (topic == null)
        //    {
        //        return NoContent();
        //    }

        //    _context.Topics.Remove(topic);
        //    await _context.SaveChangesAsync();

        //    return Accepted(topic);
        //}
    }
}