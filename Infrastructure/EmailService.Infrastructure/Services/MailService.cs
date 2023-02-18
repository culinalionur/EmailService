using EmailService.Application.Abstractions.Services;
using EmailService.Application.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml= isBodyHtml;
            mail.Subject= subject;
            if (body is null)
            {
                throw new NoBodyException();
            }
            mail.Body= body;
            mail.From = new(_configuration["Mail:UserName"]);
            await SendMailAsync(new[] {to}, subject,body,isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml= isBodyHtml;
            foreach (var to in tos)
            {
                mail.To.Add(to);
            }
            mail.Subject = subject;
            if (body is null)
            {
                throw new NoBodyException();
            }
            mail.Body = body;
            mail.From = new(_configuration["Mail:UserName"]);
            SmtpClient smtp = new();
            await smtp.SendMailAsync(mail);
        }
    }
}
