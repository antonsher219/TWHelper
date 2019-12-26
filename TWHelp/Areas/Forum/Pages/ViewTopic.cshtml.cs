using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Domain;
using Domain.Models.Identity;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWHelp.Models.DTOs;
using TWHelp.Models.DTOs.Forum;

namespace TWHelp.Areas.Forum.Pages
{
    public class PostModel : PageModel
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public PostModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public TopicDTO Topic { get; set; }
        public string WebRoot { get; set; }
        public int TopicId { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Answer { get; set; }
            public int TopicId { get; set; }
        }

        public ActionResult OnGet(int topicId)
        {
            WebRoot = "http://" + HttpContext.Request.Host.ToUriComponent();
            TopicId = topicId;

            var topic = _context.TopicQuestions.FirstOrDefault(q => q.Id == topicId);

            if(topic != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == topic.CreatorId);
                int likes = _context.TopicLikes
                    .Where(t => t.TopicId == topic.Id)
                    .Count();

                Topic = new TopicDTO()
                {
                    Title = topic.Header,
                    Question = topic.Content,
                    Author = user?.UserName,
                    AuthorProfileImage = $"data:image/png;base64,{Convert.ToBase64String(user.AvatarImage)}",
                    NumberOfLikes = likes,
                };

                if((DateTime.Now - topic.Created).Days == 0)
                {
                    Topic.Created = $"{(DateTime.Now - topic.Created).Hours} hours ago";
                }
                else
                {
                    Topic.Created = $"{(DateTime.Now - topic.Created).Days} hours ago";
                }
            }

            return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var random = new Random();

            var answer = new TopicAnswer()
            {
                AuthorId = user.Id,
                Content = Input.Answer,
                Created = DateTime.Now,
                TopicId = Input.TopicId,
                IsRigthAnswer = random.Next(0, 2) == 1 ? true : false,
            };

            _context.TopicAnswers.Add(answer);
            await _context.SaveChangesAsync();

            return new RedirectToPageResult("ViewTopic", new { topicId = Input.TopicId } );
        }
    }
}
