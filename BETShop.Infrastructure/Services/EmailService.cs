using System;
using System.Net;
using System.Threading.Tasks;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Domain.Models;
using BETShop.Infrastructure.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BETShop.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceConfiguration _configuration;

        public EmailService(EmailServiceConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(Mail mail)
        {
            var client = new SendGridClient(_configuration.ApiKey);
            var message = new SendGridMessage
            {
                From = new EmailAddress(_configuration.EmailFrom),
                Subject = mail.Subject,
                PlainTextContent = mail.Content,
                HtmlContent = mail.Content,
            };

            message.AddTo(new EmailAddress(mail.To));

            message.SetClickTracking(true, true);

            var response = await client.SendEmailAsync(message);

            if (response == null && !response.StatusCode.Equals(HttpStatusCode.Accepted))
            {
                throw new Exception($"There was an error sending the email to {mail.To}");
            }
        }
    }
}
