using ECommerce.Application.Interfaces.Mails;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace ECommerce.Infrastructure.Services.Mails
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task SendMessageAsync(string to, string subject, string body,string displayName, bool isBodyHtml = true)
        {
            await SendMessageAsync(new[] { to }, subject, body, displayName, isBodyHtml);
        }
        public async Task SendMessageAsync(string[] tos, string subject, string body,string displayName, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(configuration["Smtp:FromAddress"], displayName);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(configuration["Smtp:Username"], configuration["Smtp:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = configuration["Smtp:Host"];
            await smtp.SendMailAsync(mail);
        }
    }
}

//"Smtp": {
//    "Server": "smtp.sendgrid.net",
//    "Port": 587,
//    "FromAddress": "news@pixelplus.net",
//    "Username": "apikey",
//    "Password": "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"
//  }