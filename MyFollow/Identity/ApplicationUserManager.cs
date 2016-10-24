using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MyFollow.Models;
using MyFollow.Services;
using MyFollow.Utility;

namespace MyFollow.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            AppSettings appSettings = new AppSettings();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<MyFollowContext>()));
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };


            manager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireLowercase = true,
                RequireNonLetterOrDigit = false,
                RequireUppercase = true
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;


            manager.RegisterTwoFactorProvider("Phone code",new PhoneNumberTokenProvider<ApplicationUser>()
            {
                MessageFormat = "{0} is the OTP for your varification."
            });

            manager.RegisterTwoFactorProvider("Email code", new EmailTokenProvider<ApplicationUser>()
            {
                Subject = "Please confirm your registration",
                BodyFormat = "Your validation code {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            var dataProtection = options.DataProtectionProvider;
            if (dataProtection != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, string>(dataProtection.Create(appSettings.DataProtectionProviderKey));
            }
            return manager;
        }
    }
}