using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWHelp.Models.DTOs;
using TWHelp.Models.DTOs.Forum;

namespace TWHelp.Areas.Forum.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public bool IsHotNews { get; set; }

        public IEnumerable<IEnumerable<TopicPreviewDTO>>  HotNews { get; set; }

        public void OnGet()
        {
            FindHotNews();
        }

        private void FindHotNews()
        {
            IsHotNews = false;
        }
    }
}
