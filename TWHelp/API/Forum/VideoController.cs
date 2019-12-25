using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Domain.Models.Identity;
using TWHelp.Models.DTOs.Forum;

namespace TWHelp.API.Forum
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public VideoController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Video/all
        [HttpGet("all")]
        public ActionResult GetAllVideos()
        {
           var videos = _context.ForumVideos.Select(v => new { v.Id, v.Name, v.Created }).ToList();

            return Ok(videos);
        }

        //https://stackoverflow.com/questions/49618810/net-core-2-0-web-api-for-video-streaming-from-filestream
        //// GET: api/video/content?id=-1
        //[HttpGet("content")]
        //public IActionResult GetVideoContent(int id)
        //{
        //    var video = _context.ForumVideos.FirstOrDefault(v => v.Id == id);

        //    if(video == null)
        //    {
        //        return NotFound("video not found");
        //    }

        //    if(System.IO.File.Exists(video.VideoFilePath))
        //    {
        //        FileStream fs = System.IO.File.Open(video.VideoFilePath, FileMode.Open, FileAccess.Read);

        //        return new FileStreamResult(fs, new MediaTypeHeaderValue("video/mp4").MediaType);
        //    }

        //    return BadRequest();
        //}


        // GET: api/video/last/id?from=10&to=20
        [HttpGet("last/{id}")]
        public async Task<ActionResult<List<ForumVideoPreviewDTO>>> GetVideos(long id, int from, int to)
        {
            if(from < 0 || to < 0 || from > to)
            {
                return BadRequest("incorrect boundaries");
            }

            var videos = _context.ForumVideos
                .OrderBy(v => v.Created)
                .Skip(from)
                .Take(to - from);

            var result = new List<ForumVideoPreviewDTO>();
            var user = _context.Users.First(u => u.Id == id);

            foreach(var video in videos)
            {
                result.Add(new ForumVideoPreviewDTO()
                {
                    UserName = user.Email,
                    Name = video.Name,
                    Description = video.Description,
                    ForumVideoId = video.Id,
                    CreatedDateString = video.Created.Date.ToString("yyyy-MM-dd"),
                    CreatedTimeString = video.Created.TimeOfDay.ToString(@"hh\:mm\:ss"),
                    Tags = video.Tags
                });
            }

            return Ok(result);
        }
    }
}
