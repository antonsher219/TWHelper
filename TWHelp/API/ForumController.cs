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
using TWHelp.Models.DTOs.Forum;

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


        [HttpGet("topics/hot/get/{count}")]
        public ActionResult<List<TopicPreviewDTO>> GetHotTopicPreviews(int count)
        {
            if (count < 0)
            {
                return BadRequest();
            }

            var hotTopics = _context.TopicAnswers
                .GroupBy(
                    t => t.TopicId,
                    t => t.AuthorId,
                    (key, aggr) => new { TopicId = key, Count = aggr.Count() })
                .OrderByDescending(t => t.Count)
                .Take(count)
                .ToList();

            var result = new List<TopicPreviewDTO>();

            foreach(var item in hotTopics)
            {
                var topic = _context.TopicQuestions
                    .Where(t => t.Id == item.TopicId)
                    .FirstOrDefault();

                var topicPreivewDTO = new TopicPreviewDTO()
                {
                    TopicId = topic.Id,
                    Header = topic.Header,
                    Author = topic.Creator.UserName,
                    BackgroundImagePath = "/images/topic-preview.jpg", //TODO: add logic for choosing photo
                    AuthorImageBase64 = $"data:image/png;base64,{topic.Creator.AvatarImage.ToString()}",
                    CreatedDate = topic.Created,
                    NumberOfReplies = item.Count
                };

                result.Add(topicPreivewDTO);
            }

            return Ok(result);
        }


        [HttpGet("topics/get/{from}/{to}")]
        public ActionResult<List<TopicPreviewDTO>> GetTopicPreviews(int from, int to)
        {
            if (from < 0 || to < 0 || to < from)
            {
                return BadRequest();
            }

            List<TopicQuestion> topics = _context.TopicQuestions
                .Skip(from)
                .Take(to - from)
                .Include(t => t.Creator)
                .ToList();

            var result = new List<TopicPreviewDTO>();

            foreach(var topic in topics)
            {
                int replies = _context.TopicAnswers
                    .Where(ans => ans.TopicId == topic.Id)
                    .Count();

                var topicPreivewDTO = new TopicPreviewDTO()
                {
                    TopicId = topic.Id,
                    Header = topic.Header,
                    Author = topic.Creator.UserName,
                    BackgroundImagePath = "/images/topic-preview.jpg", //TODO: add logic for choosing photo
                    AuthorImageBase64 = $"data:image/png;base64,{topic.Creator.AvatarImage.ToString()}",
                    CreatedDate = topic.Created,
                    NumberOfReplies = replies
                };

                result.Add(topicPreivewDTO);
            }

            return Ok(result);
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