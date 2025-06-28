using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MortgageLoanCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MortgageLoanCalculator.Web.Controllers
{
    public class AccountController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }


        // POST: /Account/Register
        [HttpPost]
        public async Task<ActionResult> Register(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = email, Email = email };
                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Registration failed. Please try again.");
            }
            return View();
        }

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = await userManager.FindAsync(email, password);

                if (user != null)
                {
                    var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    authManager.SignIn(identity);
                    return RedirectToAction("Index", "Loan");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View();
        }

        // GET: /Account/Logout
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Loan");
        }






    }
}