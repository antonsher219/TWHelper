using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TWHelp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public bool IsEmailConfirmed { get; set; }
        
        public bool IsPsychologist { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Your name on the website")]
            public string NickName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Describe your education (e.g. degree)")]
            public string Education { get; set; }

            [Required]
            [Display(Name = "Describe your area of expertise (e.g. mental disorder)")]
            public string AreaOfExpertise { get; set; }

            [Required]
            [Display(Name = "Describe your work eperience (e.g. 5 years as professional psychologists in ...)")]
            public string WorkExperience { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Input = new InputModel
            {
                NickName = user.Nickname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Education = user.Education,
                AreaOfExpertise = user.AreaOfExpertise,
                WorkExperience = user.WorkExperience,
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            IsPsychologist = user.IsPsychologist;

            ViewData["IsPsychologist"] = user.IsPsychologist.ToString();
            ViewData["IsAccountActivated"] = user.IsAccountActivated.ToString();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid || (!user.IsPsychologist && ModelState.Keys.Contains("Input.")))
            {
                return Page();
            }

            user.Nickname = Input.NickName;
            user.Email = Input.Email;
            user.PhoneNumber = Input.PhoneNumber;
            user.Education = Input.Education;
            user.AreaOfExpertise = Input.AreaOfExpertise;
            user.WorkExperience = Input.WorkExperience;

            IdentityResult result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                StatusMessage = "Your profile has been updated";

                await _signInManager.RefreshSignInAsync(user);
            }
            else
            {
                StatusMessage = "Error! Something went wrong";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
