using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWHelp.Models.DTOs;
using TWHelp.Models.DTOs.Forum;

namespace TWHelp.Areas.Forum.Pages
{
    public class PostModel : PageModel
    {
        private ApplicationDbContext _context;

        public PostModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public TopicDTO Topic { get; set; }
        public List<TopicAnswerDTO> Answers { get; set; }


        public ActionResult OnGet(int topicId)
        {
            //TODO: add logic
            Topic = new TopicDTO();
            Answers = new List<TopicAnswerDTO>();

            return Page();
        }
    }
}
