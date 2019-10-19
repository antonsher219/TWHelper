using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Profiles.Pages.Psychologists
{
    public class IndexModel : PageModel
    {
        public string WebRoot { get; set; }

        public void OnGet()
        {
            WebRoot = HttpContext.Request.Host.ToUriComponent();
        }
    }
}
