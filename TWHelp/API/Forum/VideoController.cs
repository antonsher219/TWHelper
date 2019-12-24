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
        // GET: api/Video?id=-1
        [HttpGet]
        public IActionResult GetVideoContent(int id)
        {
            var video = _context.ForumVideos.FirstOrDefault(v => v.Id == id);

            if(video == null)
            {
                return NotFound("video not found");
            }

            if(System.IO.File.Exists(video.VideoFilePath))
            {
                FileStream fs = System.IO.File.Open(video.VideoFilePath, FileMode.Open, FileAccess.Read);

                return new FileStreamResult(fs, new MediaTypeHeaderValue("video/mp4").MediaType);
            }

            return BadRequest();
        }

        // POST: api/Video
        [HttpPost]
        public async Task<ActionResult> UploadVideoContent(IFormFile video, ForumVideoDTO videoDTO)
        {
            if (video == null)
            {
                return BadRequest();
            }

            string extension = Path.GetExtension(video.FileName);

            if (extension != ".mp4" && extension != ".avi")
            {
                return BadRequest("format not supported");
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("user not found. server error");
            }

            using (var stream = new MemoryStream())
            {
                await video.CopyToAsync(stream);

                //save video to dir

                //create forum video in database
            }

            return Ok();
        }

    }
}
