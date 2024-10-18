using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var smtpClient = new SmtpClient(_configuration["Email:SmtpServer"])
            {
                Port = int.Parse(_configuration["Email:SmtpPort"] ?? throw new InvalidOperationException()),
                Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]),
                EnableSsl = bool.Parse(_configuration["Email:EnableSsl"] ?? throw new InvalidOperationException()) 
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Email:FromAddress"] ?? throw new InvalidOperationException(), _configuration["Email:FromName"]),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
