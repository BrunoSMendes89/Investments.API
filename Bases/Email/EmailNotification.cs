using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Text;

namespace Bases.Email
{
    public class EmailNotification
    {
        public static async Task Send<TEntity>(string userEmail, string userName, List<TEntity> products, IConfiguration configuration)
        {
            var smtpConfiguration = configuration.GetSection("SmtpConfiguration");
            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpConfiguration["UserName"], smtpConfiguration["DisplayName"]),
                Subject = "Products that will soon expire",
                Body = GenerateEmailBody(products),
                IsBodyHtml = true,
                Priority = MailPriority.Normal,
            };
            mailMessage.To.Add(new MailAddress(userEmail, userName));
            await EmailService.SendEmail(mailMessage, configuration);
        }

        private static string GenerateEmailBody<TEntity>(List<TEntity> products)
        {
            var body = new StringBuilder();
            body.Append("<h1>Products that will soon expire</h1>");
            body.Append("<table border='1'>");
            body.Append("<tr>");

            // Adding headers dynamically based on TEntity properties
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                body.Append($"<th>{property.Name}</th>");
            }
            body.Append("</tr>");

            // Adding product rows
            foreach (var product in products)
            {
                body.Append("<tr>");
                foreach (var property in properties)
                {
                    var value = property.GetValue(product)?.ToString() ?? string.Empty;
                    body.Append($"<td>{value}</td>");
                }
                body.Append("</tr>");
            }
            body.Append("</table>");

            return body.ToString();
        }
    }
}
