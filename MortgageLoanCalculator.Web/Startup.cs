using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using MortgageLoanCalculator.Web.Models;
using Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(MortgageLoanCalculator.Web.Startup))]

namespace MortgageLoanCalculator.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            // Create the database if it doesn't exist
            using (var context = new ApplicationDbContext())
            {
                context.Database.Initialize(true);
            }


        }
    }
}
