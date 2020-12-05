using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using EZKARAPP.Models;

namespace EZKARAPP.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    var usr = await UserManager.FindAsync(model.Email, model.Password);
                    var roles = await UserManager.GetRolesAsync(usr.Id);

                    //if user is not active
                    if(!usr.Flag)
                    {
                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        ModelState.AddModelError("", "Account is locked.");
                        return View(model);
                    }
                    
                    //check whether user must change password or not.
                    if(usr.MustChangePassword)
                    {
                        
                        TempData["MustChangePassword"] = true;
                        return RedirectToAction("ChangePassword", "Manage", new { usr.Id });
                    }


                    if (roles.Contains("Guest"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "ProjectDashboard" });
                    }
                    if(roles.Contains("PCNUser"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "PCN" });
                    }
                    else if(roles.Contains("CommunicationAdministrator"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "COMM" });
                    }else if(roles.Contains("GrievanceAdministrator"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "GRM" });
                    }else if(roles.Contains("LegalAdministrator"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Legal" });
                    }
                    else if(roles.Contains("CIPAdministrator") || roles.Contains("CIPUser") || roles.Contains("CIPReport"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "CIP" });
                    }
                    else if (roles.Contains("KMDPAdministrator") || roles.Contains("KMDPUser") || roles.Contains("KMDPReport"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "KMDP" });
                    }

                    else
                    {
                        return RedirectToLocal(returnUrl);
                    }
                case SignInStatus.LockedOut:
                    ModelState.AddModelError("", "User is locked out.");
                    return View(model);
                case SignInStatus.RequiresVerification:
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}