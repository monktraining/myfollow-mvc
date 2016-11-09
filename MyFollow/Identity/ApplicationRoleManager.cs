using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MyFollow.Models;

namespace MyFollow.Identity
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> store) : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            ApplicationRoleManager manager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<MyFollowContext>()));

            if (!manager.RoleExists("Owner"))
            {
                manager.Create(new IdentityRole("Owner"));
            }

            if (!manager.RoleExists("EndUser"))
            {
                manager.Create(new IdentityRole("EndUser"));
            }

            return manager;

        }
    }
}