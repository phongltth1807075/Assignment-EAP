using Assignment_EAP_Coin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Assignment_EAP_Coin.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IUserStore<Account>, UserStore<Account>>();
            //container.RegisterType<IRoleStore<AccountRole>, RoleStore<AccountRole>>();
            container.RegisterType<UserManager<Account>>();
            container.RegisterType<DbContext, MyContext>();
            container.RegisterType<ApplicationUserManager>();
            //container.RegisterType<ApplicationRoleManager>();
            //container.RegisterType<RoleManager<AccountRole>>();

        }
    }
}