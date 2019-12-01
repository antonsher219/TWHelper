using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Forum.Pages
{
    public class QuestionModel : PageModel
    {

        public void OnGet()
        {
        }

        public ActionResult OnPostCreateNewTopic()
        {
            return BadRequest();
        }
    }
}
