using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using MyFollow.Utility;

namespace MyFollow.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            AppSettings appSettings = new AppSettings();
            using (SmtpClient client = new SmtpClient())
            {
                MailAddress fromAddress = new MailAddress(appSettings.FromAddress);
                MailAddress toAddress = new MailAddress(message.Destination);
                MailMessage mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Body = message.Body,
                    IsBodyHtml = true
                };
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}