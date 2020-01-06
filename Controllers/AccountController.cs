using Assignment_EAP_Coin.App_Start;
using Assignment_EAP_Coin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment_EAP_Coin.Controllers
{
    public class AccountController : Controller
    {
        
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        private MyContext _dbContext;

        private ApplicationUserManager _userManager;

        public AccountController(MyContext dbContext, ApplicationUserManager myUserManager)
        {
            _dbContext = dbContext;
            _userManager = myUserManager;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Account account = _userManager.Find(username, password);

            if (account == null)
            {
                return HttpNotFound();
            }
            // success
            var ident = _userManager.CreateIdentity(account, DefaultAuthenticationTypes.ApplicationCookie);
            //use the instance that has been created. 
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect("/Home");
        }


        // GET: Accounts
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Store(string username, string password,string email)
        {
            var account = new Account()
            {
                UserName = username,
                Email = email,
                Avatar = "avatar",
                Birthday = DateTime.Now,
                CreatedAt = DateTime.Now
            };
            IdentityResult result = await _userManager.CreateAsync(account, password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(account.Id, "User");
                //string code = await _userManager.GenerateEmailConfirmationTokenAsync(account.Id);
                ////            var provider = new DpapiDataProtectionProvider("SampleAppName");

                ////            var userManager = new UserManager<Account>(new UserStore<Account>());
                ////            userManager.UserTokenProvider = new DataProtectorTokenProvider<Account>(
                ////provider.Create("SampleTokenName"));
                //await _userManager.SendEmailAsync(account.Id, "Hello world! Please confirm your account", "<b>Please confirm your account</b> by clicking <a href=\"http://google.com.vn\">here</a>");
                return RedirectToAction("Index", "Home");
            }
            return View("Login");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Home");
        }
    }
}