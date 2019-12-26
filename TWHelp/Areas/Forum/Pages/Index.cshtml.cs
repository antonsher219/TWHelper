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

        public string WebRoot { get; set; }

        public void OnGet()
        {
            WebRoot = "http://" + HttpContext.Request.Host.ToUriComponent();
        }
    }
}
