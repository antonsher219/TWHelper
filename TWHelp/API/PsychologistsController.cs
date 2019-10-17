using Domain.Models.Identity;
using Infrastructure;
using TWHelp.Models.DTOs;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace TWHelp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsychologistsController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;


        public PsychologistsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: api/psychologists/all
        [HttpGet("all")]
        public async Task<ActionResult<List<PsychologistDTO>>> GetAllPsychologists()
        {
            User user = await _userManager.GetUserAsync(User);

            List<User> psychoUsers = _context
                .Users
                .Where(u => u.IsPsychologist)
                .ToList();

            var psychos = new List<PsychologistDTO>();

            foreach (var psychoUser in psychoUsers)
            {
                //show on UI like from current user to specific psycho
                bool isCurrentUserSetLike = _context
                    .Likes
                    .Where(l => l.UserId == user.Id)
                    .Any();

                int likes = _context
                    .Likes
                    .Where(l => l.PsychologistId == psychoUser.Id)
                    .Count();

                psychos.Add(new PsychologistDTO()
                {
                    Age = psychoUser.Age,
                    AvatarImage = psychoUser.AvatarImage,
                    IsAccountActivated = psychoUser.IsAccountActivated,
                    Education = psychoUser.Education,
                    AreaOfExpertise = psychoUser.AreaOfExpertise,
                    WorkExperience = psychoUser.WorkExperience,

                    IsCurrentUserSetLike = isCurrentUserSetLike,
                    Likes = likes
                });
            }

            return Ok(psychos);
        }

        // GET: api/psychologists/{id}
        [HttpGet("{id}")]
        public ActionResult<PsychologistDTO> GetPsychologist(long id)
        {
            User psycho = _context
                .Users
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if(psycho == null)
            {
                return NotFound();
            }

            return Ok(psycho);
        }
    }
}
