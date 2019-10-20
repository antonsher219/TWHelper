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
                psychos.Add(MakePsychologistDTO(user, psychoUser));
            }

            return Ok(psychos);
        }

        // GET: api/psychologists/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PsychologistDTO>> GetPsychologist(long id)
        {
            User user = await _userManager.GetUserAsync(User);

            User psychoUser = _context
                .Users
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if (user == null || psychoUser == null)
            {
                return NotFound();
            }

            PsychologistDTO psychoDTO = MakePsychologistDTO(user, psychoUser);

            return Ok(psychoDTO);
        }

        private PsychologistDTO MakePsychologistDTO(User user, User psychoUser)
        {
            //check if current user like for psycho
            bool isCurrentUserSetLike = _context
                .Likes
                .Where(l => l.UserId == user.Id && l.PsychologistId == psychoUser.Id)
                .Any();

            //number of all likes
            int likes = _context
                .Likes
                .Where(l => l.PsychologistId == psychoUser.Id)
                .Count();

            //prepare DTO
            PsychologistDTO psychoDTO = new PsychologistDTO()
            {
                Id = psychoUser.Id,

                NickName = psychoUser.Nickname,
                Age = psychoUser.Age,
                AvatarImage = psychoUser.AvatarImage,
                IsAccountActivated = psychoUser.IsAccountActivated,
                Education = psychoUser.Education,
                AreaOfExpertise = psychoUser.AreaOfExpertise,
                WorkExperience = psychoUser.WorkExperience,

                IsCurrentUserSetLike = isCurrentUserSetLike,
                Likes = likes
            };

            return psychoDTO;
        }
    }
}
