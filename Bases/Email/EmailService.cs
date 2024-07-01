using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Bases.Email
{
    public class EmailService
    {
        public static async Task SendEmail(MailMessage mailMessage, IConfiguration configuration)
        {
            var smtpConfiguration = configuration.GetSection("SmtpConfiguration");
            using var smtpClient = new SmtpClient(smtpConfiguration["Server"], 587)
            {
                Credentials = new NetworkCredential(smtpConfiguration["UserName"], smtpConfiguration["Password"]),
                EnableSsl = true
            };

            await smtpClient .SendMailAsync(mailMessage);
        }
    }
}
