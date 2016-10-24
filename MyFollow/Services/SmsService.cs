using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using System.Text;
using MyFollow.Utility;

namespace MyFollow.Services
{
    public class SmsService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            AppSettings appSettings = new AppSettings();
            //Multiple mobiles numbers separated by comma
            string mobileNumber = message.Destination;
            //Your message to send, Add URL encoding here.
            string sms = HttpUtility.UrlEncode(message.Body);

            Dictionary<string, string> formData = new Dictionary<string, string>
            {
                {"authkey", appSettings.SmsAuthKey},
                {"mobiles", mobileNumber},
                {"message", sms},
                {"sender", appSettings.SmsSenderId},
                {"route", "4"}
            };

            //Call Send SMS API
            string sendSMSUri = "https://control.msg91.com/api/sendhttp.php";

            using (HttpClient client = new HttpClient())
                await client.PostAsync(sendSMSUri, new FormUrlEncodedContent(formData));
        }
    }
}