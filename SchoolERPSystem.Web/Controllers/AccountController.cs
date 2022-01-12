using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SchoolERPSystem.Models;
using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Service;
using SchoolERPSystem.Service.DependenciesService.Interfaces;
using SchoolERPSystem.Service.StaffModelService.Interfaces;
using SchoolERPSystem.Web.Models;

namespace SchoolERPSystem.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ApplicationDbContext context;

        IGenderService _GenderService;
        IDepartmentService _DepartmentService;
        IDesignationService _DesignationService;
        IMaritalStatusService _MaritalStatusService;
        IStaffProfileService _StaffProfileService;

        IUserLogService _userLogService;

        //public AccountController()
        //{
        //    context = new ApplicationDbContext();   
        //}

        public AccountController(IStaffProfileService staffProfileService, IUserLogService userLogService, IGenderService genderService, IDepartmentService departmentService, IDesignationService designationService, IMaritalStatusService maritalStatusService)
        {
            _StaffProfileService = staffProfileService;
            _userLogService = userLogService;
            context = new ApplicationDbContext();
            _GenderService = genderService;
            _MaritalStatusService = maritalStatusService;
            _DesignationService = designationService;
            _DepartmentService = departmentService;
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        public ActionResult Index()
        {
            IEnumerable<RegisterViewModel> staffprofile = _StaffProfileService.GetAll().Select(s => new RegisterViewModel
            {
                UserRoles = s.RoleName,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GenderId = s.GenderId,
                GenderName = s.GenderName.GenderName,
                DepartmentId = s.DepartmentId,
                DepartmentName = s.DepartmentName.Name,
                DesignationId = s.DesignationId,
                DesignationName = s.DesignationName.Name,
                UserName = s.ApplicationUser.UserName,
                Email = s.ApplicationUser.Email,
                Mobile = s.Mobile,
                MaritalStatusId = s.MaritalStatusId,
                MaritalStatusName = s.MaritalStatusName.MaritalStatusName,
                Id = s.Id
            });
            return View(staffprofile);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffProfile staffProfile = _StaffProfileService.GetById(id.Value);
            RegisterViewModel model = new RegisterViewModel
            {
                Id = staffProfile.Id,
                UserRoles = staffProfile.RoleName,
                FirstName = staffProfile.FirstName,
                LastName = staffProfile.LastName,
                GenderId = staffProfile.GenderId,
                GenderName = staffProfile.GenderName.GenderName,
                DepartmentId = staffProfile.DepartmentId,
                DepartmentName = staffProfile.DepartmentName.Name,
                DesignationId = staffProfile.DesignationId,
                DesignationName = staffProfile.DesignationName.Name,
                UserName = staffProfile.ApplicationUser.UserName,
                Email = staffProfile.ApplicationUser.Email,
                Mobile = staffProfile.Mobile,
                MaritalStatusId = staffProfile.MaritalStatusId,
                MaritalStatusName = staffProfile.MaritalStatusName.MaritalStatusName,
            };
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffProfile staffProfile = _StaffProfileService.GetById(id.Value);
            RegisterViewModel model = new RegisterViewModel
            {
                UserRoles = staffProfile.RoleName,
                FirstName = staffProfile.FirstName,
                LastName = staffProfile.LastName,
                GenderId = staffProfile.GenderId,
                GenderName = staffProfile.GenderName.GenderName,
                DepartmentId = staffProfile.DepartmentId,
                DepartmentName = staffProfile.DepartmentName.Name,
                DesignationId = staffProfile.DesignationId,
                DesignationName = staffProfile.DesignationName.Name,
                UserName = staffProfile.ApplicationUser.UserName,
                Email = staffProfile.ApplicationUser.Email,
                Mobile = staffProfile.Mobile,
                MaritalStatusId = staffProfile.MaritalStatusId,
                MaritalStatusName = staffProfile.MaritalStatusName.MaritalStatusName,
            };
            if (model == null)
            {
                return HttpNotFound();
            }

            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Superadmin")).ToList(), "Name", "Name");
            ViewBag.GenderId = new SelectList(_GenderService.GetAll(), "Id", "GenderName", model.GenderId);
            ViewBag.MaritalStatusId = new SelectList(_MaritalStatusService.GetAll(), "Id", "MaritalStatusName", model.MaritalStatusId);
            ViewBag.DepartmentId = new SelectList(_DepartmentService.GetAll(), "Id", "Name", model.DepartmentId);
            ViewBag.DesignationId = new SelectList(_DesignationService.GetAll(), "Id", "Name", model.DesignationId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                StaffProfile s = _StaffProfileService.GetById(model.Id);
                s.RoleName = model.UserRoles;
                s.FirstName = model.FirstName;
                s.LastName = model.LastName;
                s.GenderId = model.GenderId;
                s.DepartmentId = model.DepartmentId;
                s.DesignationId = model.DesignationId;
                s.ApplicationUser.UserName = model.UserName;
                s.ApplicationUser.Email = model.Email;
                s.Mobile = model.Mobile;
                s.MaritalStatusId = model.MaritalStatusId;
                _StaffProfileService.Update(s);
                if (s.Id > 0)
                {
                    RedirectToAction("Index");
                }
            }
            else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
            }

            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Superadmin")).ToList(), "Name", "Name");
            ViewBag.GenderId = new SelectList(_GenderService.GetAll(), "Id", "GenderName", model.GenderId);
            ViewBag.MaritalStatusId = new SelectList(_MaritalStatusService.GetAll(), "Id", "MaritalStatusName", model.MaritalStatusId);
            ViewBag.DepartmentId = new SelectList(_DepartmentService.GetAll(), "Id", "Name", model.DepartmentId);
            ViewBag.DesignationId = new SelectList(_DesignationService.GetAll(), "Id", "Name", model.DesignationId);
            return View(model);
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
            Microsoft.VisualBasic.Devices.ComputerInfo OS = new Microsoft.VisualBasic.Devices.ComputerInfo();
            if (ModelState.IsValid)
            {
               
                var user = await UserManager.FindAsync(model.Username, model.Password);
                if (user != null)
                {
                    var roles = UserManager.GetRoles(user.Id).FirstOrDefault();
                    UserLog userLogModel = new UserLog
                    {
                        IPAddress = Request.ServerVariables["REMOTE_ADDR"],
                        LoginDate = DateTime.Now,
                        UserAgent = HttpContext.Request.Browser.Browser + " " + HttpContext.Request.Browser.Version + ", " + OS.OSFullName.Trim(),
                        Username = user.UserName,
                        Email = user.Email,
                        ApplicationUserId = user.Id,
                        RoleName = roles
                    };
                    _userLogService.Create(userLogModel);
                    var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: false);

                    switch (result)
                    {
                        case SignInStatus.Success:
                            //return RedirectToLocal(returnUrl);
                            return RedirectToAction("Index", "Dashboard", new { area = "admin" });
                        case SignInStatus.LockedOut:
                            return View("Lockout");
                        case SignInStatus.RequiresVerification:
                            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                        case SignInStatus.Failure:
                        default:
                            ModelState.AddModelError("", "Invalid login attempt.");
                            return View(model);
                    }
                }
                ModelState.AddModelError("", "Invalid Username or Password");
            }

            return View(model);
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true

        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Superadmin")).ToList(), "Name", "Name");
            ViewBag.GenderId = new SelectList(_GenderService.GetAll(), "Id", "GenderName");
            ViewBag.MaritalStatusId = new SelectList(_MaritalStatusService.GetAll(), "Id", "MaritalStatusName");
            ViewBag.DepartmentId = new SelectList(_DepartmentService.GetAll(), "Id", "Name");
            ViewBag.DesignationId = new SelectList(_DesignationService.GetAll(), "Id", "Name");

            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);

                    StaffProfile staffmodel = new StaffProfile
                    {
                        ApplicationUserId = user.Id,
                        DepartmentId = model.DepartmentId,
                        RoleName = model.UserRoles, 
                        DesignationId = model.DesignationId,
                        GenderId = model.GenderId,
                        MaritalStatusId = model.MaritalStatusId,
                        Mobile = model.Mobile,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfBirth = model.DateOfBirth,
                        DateOfJoining = model.DateOfJoining,
                        CurrentAddress = model.CurrentAddress,
                        EmergencyContact = model.EmergencyContact,
                        FatherName = model.FatherName,
                        MotherName = model.MotherName,
                        Note = model.Note
                    };
                    _StaffProfileService.Create(staffmodel);

                    //Ends Here
                    return RedirectToAction("Index", "Account");
                }
                ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Superadmin")).ToList(), "Name", "Name");
                ViewBag.GenderId = new SelectList(_GenderService.GetAll(), "Id", "GenderName", model.GenderId);
                ViewBag.MaritalStatusId = new SelectList(_MaritalStatusService.GetAll(), "Id", "MaritalStatusName", model.MaritalStatusId);
                ViewBag.DepartmentId = new SelectList(_DepartmentService.GetAll(), "Id", "Name", model.DepartmentId);
                ViewBag.DesignationId = new SelectList(_DesignationService.GetAll(), "Id", "Name", model.DesignationId);
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
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
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

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

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}