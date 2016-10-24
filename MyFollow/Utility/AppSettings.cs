using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyFollow.Utility
{
    public class AppSettings
    {
        private string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public string FromAddress => GetSetting("FromAddress");
        public string SmsAuthKey => GetSetting("SmsAuthKey");
        public string SmsSenderId => GetSetting("SmsSenderId");
        public string DataProtectionProviderKey => GetSetting("DataProtectionKey");
    }
}