using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Domain;
using Domain.Models.Identity;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Identity.Pages.Account.Manage
{
    public class ApproveModel : PageModel
    {
        public ApplicationDbContext context;
        public UserManager<User> userManager;

        public ApproveModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string FacebookLink { get; set; }
            public string TwitterLink { get; set; }
            public string LinkedInLink { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync(IEnumerable<IFormFile> files)
        {
            var user = await userManager.GetUserAsync(User);

            var psychoRequest = new PsychoApproveRequest()
            {
                PsychoId = user.Id,
                Created = DateTime.Now,
                FacebookLink = Input.FacebookLink,
                TwitterLink = Input.TwitterLink,
                LinkedInLink = Input.LinkedInLink,
            };

            var index = 0;
            foreach(var file in files)
            {
                string fileName = $@"\approveRequests\{user.Email}_{DateTime.Now.ToString("yyyy-MM-ddThh-mm-ss")}_{file.FileName}";

                using (var fileStream = new FileStream(".\\wwwroot" + fileName, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                switch(index)
                {
                    case 0: psychoRequest.DegreeDiplomaFilePath = fileName; break;
                    case 1: psychoRequest.PhDDiplomaFilePath = fileName; break;
                    case 2: psychoRequest.ResearchDiplomaFilePath = fileName; break;
                }

                index += 1;
            }

            context.PsychoApproveRequests.Add(psychoRequest);
            context.SaveChanges();
        }
    }
}
