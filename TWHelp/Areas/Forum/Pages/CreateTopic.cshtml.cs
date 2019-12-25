using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Domain;
using Domain.Models.Identity;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Forum.Pages
{
    public class CreateTopicModel : PageModel
    {
        private ApplicationDbContext context;
        private UserManager<User> userManager;

        public CreateTopicModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
            [DataType(DataType.Text)]
            public string Title { get; set; }

            [Required]
            [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 20)]
            [DataType(DataType.Text)]
            public string Description { get; set; }
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);

                var question = new TopicQuestion()
                {
                    Header = Input.Title,
                    Content = Input.Description,
                    Created = DateTime.Now,
                    CreatorId = user.Id,
                };

                var addedQuestion = context.TopicQuestions.Add(question).Entity;
                context.SaveChanges();

                return new RedirectToPageResult("ViewTopic", new { topicId = addedQuestion.Id });
            }
            //else
            //{
            //    foreach (var error in ModelState.Values)
            //    {
            //        foreach(var modelError in error.Errors)
            //        {
            //            ModelState.AddModelError(string.Empty, modelError.ErrorMessage);
            //        }
            //    }
            //}

            return Page();
        }
    }
}
