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
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [TempData]
        public bool IsHotNews { get; set; }

        public IEnumerable<IEnumerable<TopicPreviewDTO>>  HotNews { get; set; }

        public void OnGet()
        {
            FindHotNews(12);
        }

        private void FindHotNews(int count)
        {
            IsHotNews = false;

            var hotTopics = _context.TopicAnswers
                .GroupBy(
                    t => t.TopicId,
                    t => t.AuthorId,
                    (key, aggr) => new { TopicId = key, Count = aggr.Count() })
                .OrderByDescending(t => t.Count)
                .Take(count)
                .ToList();

            var result = new List<TopicPreviewDTO>();

            foreach (var item in hotTopics)
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

            if(result.Count == 0)
            {
                IsHotNews = false;
            }
            else
            {

            }
        }
    }
}
