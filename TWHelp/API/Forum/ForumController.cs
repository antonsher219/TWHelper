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
using TWHelp.Models.DTOs.Forum.Preview;

namespace TWHelp.API.Forum
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


        //[HttpGet("topics/hot/get/{count}")]
        //public ActionResult<List<TopicPreviewDTO>> GetHotTopicPreviews(int count)
        //{
        //    if (count < 0)
        //    {
        //        return BadRequest();
        //    }

        //    var hotTopics = _context.TopicAnswers
        //        .GroupBy(
        //            t => t.TopicId,
        //            t => t.AuthorId,
        //            (key, aggr) => new { TopicId = key, Count = aggr.Count() })
        //        .OrderByDescending(t => t.Count)
        //        .Take(count)
        //        .ToList();

        //    var result = new List<TopicPreviewDTO>();

        //    foreach(var item in hotTopics)
        //    {
        //        var topic = _context.TopicQuestions
        //            .Where(t => t.Id == item.TopicId)
        //            .FirstOrDefault();

        //        var topicPreivewDTO = new TopicPreviewDTO()
        //        {
        //            TopicId = topic.Id,
        //            Header = topic.Header,
        //            Author = topic.Creator.UserName,
        //            BackgroundImagePath = "/images/topic-preview.jpg", //TODO: add logic for choosing photo
        //            AuthorImageBase64 = $"data:image/png;base64,{topic.Creator.AvatarImage.ToString()}",
        //            CreatedDate = topic.Created,
        //            NumberOfReplies = item.Count
        //        };

        //        result.Add(topicPreivewDTO);
        //    }

        //    return Ok(result);
        //}

        //GET: api/forum/topics/last?from=10&to=20
        [HttpGet("topics/last")]
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

            foreach (var topic in topics)
            {
                int replies = _context.TopicAnswers
                    .Where(ans => ans.TopicId == topic.Id)
                    .Count();

                var random = new Random();

                var topicPreivewDTO = new TopicPreviewDTO()
                {
                    TopicId = topic.Id,
                    Header = topic.Header,
                    Author = topic.Creator.UserName,
                    NumberOfReplies = replies
                };

                if ((DateTime.Now - topic.Created).Days > 0)
                {
                    topicPreivewDTO.Created = (DateTime.Now - topic.Created).Days.ToString() + " days ago";
                }
                else
                {
                    topicPreivewDTO.Created = (DateTime.Now - topic.Created).Hours.ToString() + " hours ago";
                }

                result.Add(topicPreivewDTO);
            }

            return Ok(result);
        }

        //GET: api/forum/authors/last?count=20
        [HttpGet("authors/last")]
        public ActionResult<List<AuthorPreviewDTO>> GetAuthors(int count)
        {
            if (count < 0)
            {
                return BadRequest();
            }

            var activeAuthors = _context.TopicAnswers
                .GroupBy(
                    t => t.AuthorId,
                    (key, aggr) => new { AuthorId = key, Count = aggr.Count() })
                .OrderByDescending(t => t.Count)
                .Take(count)
                .ToList();

            var result = new List<AuthorPreviewDTO>();

            foreach (var author in activeAuthors)
            {
                User user = _context.Users.Find(author.AuthorId);

                result.Add(new AuthorPreviewDTO() 
                { 
                    AuthorName = user.UserName,
                    ActivityCount = author.Count
                });
            }

            return Ok(result);
        }


        //GET: api/forum/surveys/last?from=10&to=20
        [HttpGet("surveys/last")]
        public ActionResult<List<Survey>> GetSurveys(int from, int to)
        {
            if (from < 0 || to < 0 || to < from)
            {
                return BadRequest();
            }

            var result = _context.Surveys
                .Skip(from)
                .Take(to - from)
                .ToList();

            return Ok(result);
        }
    }
}