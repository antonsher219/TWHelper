using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TWHelp.Models.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        public EmailSender(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string key = _config["Security:Tokens:EmailSendGrid:FirstAPIKey"];
            var client = new SendGridClient(key);
            var from = new EmailAddress("den.vys@gmail.com", "Den =)");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, subject, htmlMessage);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
