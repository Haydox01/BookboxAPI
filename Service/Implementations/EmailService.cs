using System.Net;
using System.Net.Mail;
using Bookbox.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Bookbox.Service.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(string receptor, string subject, string body)
        {
            var email = configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
            var password = configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
            var host = configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
            var port = configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

            /* var smtpClient = new SmtpClient(host, port);
             smtpClient.EnableSsl = true;
             smtpClient.UseDefaultCredentials = false;

             smtpClient.Credentials = new NetworkCredential(email, password);*/

            var smtpClient = new SmtpClient(host, port)
            {
                EnableSsl = true,  // Use SSL/TLS on port 587
                Credentials = new NetworkCredential(email, password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 20000 // Optional: Set timeout for the request
            };
            var message = new MailMessage(email!, receptor, subject, body);
            await smtpClient.SendMailAsync(message);
        }
    }
}
