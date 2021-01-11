using Microsoft.Extensions.Configuration;
using Restaurants.Users.Api.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Restaurants.Users.Api.Helpers
{
    /// <summary>
    /// This helper implements a convenience wrapper around the built-in SMTP Client.
    /// To use this class, you'll need to create an account with a SMTP provider such as
    /// MailGun, SendGrid or Amazon Simple Email Service. Then register your SMTP client API 
    /// credentials in the appsettings.json file by adding a section with the following format:
    /// 
    /// "SMTP": {
    ///     "Host": "URI or IP",
    ///     "Username": "String",
    ///     "Password": "String",
    ///     "Port": "Integer string",
    ///     "AuthType": "tls",
    ///     "From": "info@example.com"
    /// },
    /// </summary>
    public static class EmailHelper
    {
        public static bool SendEmail(IConfiguration appConfig, List<string> toList, List<string> ccList,
                                     List<string> bccList, string subject, string body, bool isHtml)
        {
            var client = new SmtpClient(appConfig["SMTP:Host"], int.Parse(appConfig["SMTP:Port"]));
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(appConfig["SMTP:Username"], appConfig["SMTP:Password"]);
            client.EnableSsl = true;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(appConfig["SMTP:From"]);

            foreach (var to in toList ?? new List<string>())
            {
                mailMessage.To.Add(to);
            }

            foreach (var cc in ccList ?? new List<string>())
            {
                mailMessage.CC.Add(cc);
            }

            foreach (var bcc in bccList ?? new List<string>())
            {
                mailMessage.Bcc.Add(bcc);
            }

            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isHtml;

            client.Send(mailMessage);

            return true;
        }
        
        public static bool SendPasswordResetLink(IConfiguration appConfig, AppUserModel user, string token)
        {
            var to = new List<string>() { user.Email };
            var encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Email));
            var resetLink = $"{appConfig["AppBaseUrl"]}reset-password?token={token}&user={encodedEmail}";
            var resetElement = $"<a target=\"_blank\" href=\"{resetLink}\">{resetLink}</a>";
            var subject = "Password Reset Link";
            
            var fileDir = appConfig["MediaBaseDir"] + "EmailTemplates" + Path.DirectorySeparatorChar;
            var filename = fileDir + "SendPasswordResetLink.html";
            var body = File.ReadAllText(filename);
            body = body.Replace("#{RESET_LINK}}#", resetElement);

            return SendEmail(appConfig, to, null, null, subject, body, true);
        }
    }
}
