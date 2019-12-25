using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Forum.Pages
{
    public class PsychoTestsModel : PageModel
    {
        public string WebRoot { get; set; }

        public void OnGet()
        {
            WebRoot = "http://" + HttpContext.Request.Host.ToUriComponent();
        }
    }
}
