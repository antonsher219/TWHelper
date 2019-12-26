using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Forum.Pages
{
    public class TakeTestModel : PageModel
    {
        private ApplicationDbContext context;

        public TakeTestModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Survey Input { get; set; }

        public void OnGet(int surveyId)
        {
            Input = context.Surveys.FirstOrDefault(s => s.Id == surveyId);
        }

        public async Task OnPostAsync()
        {

        }
    }
}
