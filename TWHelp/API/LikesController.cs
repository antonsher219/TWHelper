using Domain.Models.Identity;
using Infrastructure;

using System.Collections.Generic;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System;
using Domain.Models.Domain;

namespace TWHelp.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public LikesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/likes/all/profiles
        [HttpGet("all/profiles")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllLikedProfiles()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                List<long> likedProfilesIDs = _context
                    .Likes
                    .Where(like => like.UserId == user.Id)
                    .Select(like => like.PsychologistId)
                    .Union(_context
                            .Likes
                            .Where(like => like.PsychologistId == user.Id)
                            .Select(like => like.UserId))
                    .ToList();

                List<User> users = _context
                    .Users
                    .Where(u => likedProfilesIDs.Contains(u.Id))
                    .ToList();

                return Ok(users);
            }

            return BadRequest("server error. user is null");
        }

        // POST: api/likes/{id}
        [HttpPost("{id}")]
        public async Task<ActionResult<User>> AddLikeToProfile(long id)
        {
            var user = await _userManager.GetUserAsync(User);

            if(user != null)
            {
                User likedProfile = _context
                    .Users
                    .Where(u => u.Id == id)
                    .FirstOrDefault();

                if(likedProfile == null)
                {
                    return BadRequest("user not found");
                }

                if(user.IsPsychologist || !likedProfile.IsPsychologist)
                {
                    return BadRequest("only user can add likes to only psychologists");
                }

                Like like = new Like
                {
                    UserId = user.Id,
                    PsychologistId = likedProfile.Id
                };

                await _context.Likes.AddAsync(like);
                await _context.SaveChangesAsync();
            }

            return BadRequest("server error. user is null");
        }


        // DELETE: api/likes/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                User likedProfile = _context
                    .Users
                    .Where(u => u.Id == id)
                    .FirstOrDefault();

                if (likedProfile == null)
                {
                    return BadRequest("user not found");
                }

                Like like = _context
                    .Likes
                    .Where(l => l.UserId == user.Id && l.PsychologistId == likedProfile.Id)
                    .FirstOrDefault();

                if(like == null)
                {
                    return BadRequest("this user did not add like for this id user");
                }

                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
            }

            return BadRequest("server error. user is null");
        }
    }
}
