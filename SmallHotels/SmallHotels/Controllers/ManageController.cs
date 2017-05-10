using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SmallHotels.Common.Constants;
using SmallHotels.DataServices.Contracts;
using SmallHotels.Common.Contracts;
using SmallHotels.Auth;
using Microsoft.AspNet.Identity.Owin;
using SmallHotels.Models.ManageViewModels;

namespace SmallHotels.Controllers
{
    public enum ManageMessageId
    {
        AddPhoneSuccess,
        ChangePasswordSuccess,
        SetTwoFactorSuccess,
        SetPasswordSuccess,
        RemoveLoginSuccess,
        RemovePhoneSuccess,
        Error
    }

    [Authorize]
    public class ManageController : Controller
    {
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private readonly IBookRoomService bookRoomService;
        private readonly IUserInfoService userInfoService;
        //private readonly IHotelService HotelService;
        private readonly IUtilitiesService utils;

        private ApplicationSignInManager signInManager;
        private ApplicationUserManager userManager;

        public ManageController()
        {
        }

        public ManageController(IBookRoomService bookRoomService, IUserInfoService userInfoService, IUtilitiesService utils)
        {
            this.bookRoomService = bookRoomService;
            this.userInfoService = userInfoService;
            this.utils = utils;
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this.signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }

            private set
            {
                this.signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this.userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }

        public async Task<ActionResult> Index(ManageMessageId? message, int? page)
        {
            this.ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : string.Empty;

            var userId = this.User.Identity.GetUserId();
            var pagesCount = this.bookRoomService.GetPagesCountForUser(userId, PageConstants.ProfilePageCount);
            var currentPage = this.utils.GetPage(page, pagesCount);
            var bookedRooms = this.bookRoomService.GetBookedRoomsForUser(userId, currentPage, PageConstants.ProfilePageCount);
            var model = new IndexViewModel
            {
                HasPassword = this.HasPassword(),
                PhoneNumber = await this.UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await this.UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await this.UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await this.AuthenticationManager.TwoFactorBrowserRememberedAsync(userId),
                BookRooms = bookedRooms,
                PagesCount = pagesCount,
                CurrentPage = currentPage,
                PreviousPage = currentPage - 1,
                NextPage = currentPage + 1
            };

            return this.View(model);
        }

        public ActionResult EditUserInfo()
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.userInfoService.GetById(userId);

            var model = new IndexViewModel
            {
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return this.PartialView("_UserEditInfoPartial", model);
        }

        [HttpPost]
        public ActionResult EditUserInfo(IndexViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView("_UserEditInfoPartial", model);
            }

            var userId = this.User.Identity.GetUserId();
            this.userInfoService.UpdateUserInfoByUser(userId, model.FirstName, model.LastName, model.PhoneNumber, model.Address);

            return this.PartialView("_UserEditInfoPartial", model);
        }

        public ActionResult GetUserBookedRooms(int? page)
        {
            var userId = this.User.Identity.GetUserId();
            var pagesCount = this.bookRoomService.GetPagesCountForUser(userId, PageConstants.ProfilePageCount);
            var currentPage = this.utils.GetPage(page, pagesCount);
            var bookedRooms = this.bookRoomService.GetBookedRoomsForUser(userId, currentPage, PageConstants.ProfilePageCount);

            var model = new IndexViewModel
            {
                BookRooms = bookedRooms,
                PagesCount = pagesCount,
                CurrentPage = currentPage,
                PreviousPage = currentPage - 1,
                NextPage = currentPage + 1
            };

            return this.PartialView("_UserBookedRoomsPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await this.UserManager.RemoveLoginAsync(this.User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }

                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }

            return this.RedirectToAction("ManageLogins", new { Message = message });
        }

        public ActionResult AddPhoneNumber()
        {
            return this.View();
        }

        public ActionResult ChangePassword()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.UserManager.ChangePasswordAsync(this.User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }

                return this.RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }

            this.AddErrors(result);
            return this.View(model);
        }

        public ActionResult SetPassword()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.UserManager.AddPasswordAsync(this.User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                    if (user != null)
                    {
                        await this.SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }

                    return this.RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }

                this.AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, this.Url.Action("LinkLoginCallback", "Manage"), this.User.Identity.GetUserId());
        }

        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await this.AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, this.User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return this.RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }

            var result = await this.UserManager.AddLoginAsync(this.User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? this.RedirectToAction("ManageLogins") : this.RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.userManager != null)
            {
                this.userManager.Dispose();
                this.userManager = null;
            }

            base.Dispose(disposing);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error);
            }
        }

        private bool HasPassword()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }

            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }

            return false;
        }
    }

    //    [Authorize]
    //    public class ManageController : Controller
    //    {
    //        private readonly ISignInService signInService;
    //        private readonly IUserService userService;

    //        public ManageController(ISignInService signInService, IUserService userService)
    //        {
    //            this.signInService = signInService;
    //            this.userService = userService;
    //        }

    //        //
    //        // GET: /Manage/Index
    //        public async Task<ActionResult> Index(ManageMessageId? message)
    //        {
    //            ViewBag.StatusMessage =
    //                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
    //                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
    //                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
    //                : message == ManageMessageId.Error ? "An error has occurred."
    //                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
    //                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
    //                : "";

    //            var userId = User.Identity.GetUserId();
    //            var model = new IndexViewModel
    //            {
    //                HasPassword = HasPassword(),
    //                PhoneNumber = await this.userService.GetPhoneNumberAsync(userId),
    //                TwoFactor = await this.userService.GetTwoFactorEnabledAsync(userId),
    //                Logins = await this.userService.GetLoginsAsync(userId),
    //                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
    //            };
    //            return View(model);
    //        }

    //        //
    //        // POST: /Manage/RemoveLogin
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
    //        {
    //            ManageMessageId? message;
    //            var result = await this.userService.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
    //            if (result.Succeeded)
    //            {
    //                var user = await this.userService.FindByIdAsync(User.Identity.GetUserId());
    //                if (user != null)
    //                {
    //                    await this.signInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //                }
    //                message = ManageMessageId.RemoveLoginSuccess;
    //            }
    //            else
    //            {
    //                message = ManageMessageId.Error;
    //            }
    //            return RedirectToAction("ManageLogins", new { Message = message });
    //        }

    //        //
    //        // GET: /Manage/AddPhoneNumber
    //        public ActionResult AddPhoneNumber()
    //        {
    //            return View();
    //        }

    //        //
    //        // POST: /Manage/AddPhoneNumber
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
    //        {
    //            if (!ModelState.IsValid)
    //            {
    //                return View(model);
    //            }
    //            // Generate the token and send it
    //            var code = await this.userService.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
    //            if (this.userService.SmsService != null)
    //            {
    //                var message = new IdentityMessage
    //                {
    //                    Destination = model.Number,
    //                    Body = "Your security code is: " + code
    //                };
    //                await this.userService.SmsService.SendAsync(message);
    //            }
    //            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
    //        }

    //        //
    //        // POST: /Manage/EnableTwoFactorAuthentication
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<ActionResult> EnableTwoFactorAuthentication()
    //        {
    //            await this.userService.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
    //            var user = await this.userService.FindByIdAsync(User.Identity.GetUserId());
    //            if (user != null)
    //            {
    //                await this.signInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //            }
    //            return RedirectToAction("Index", "Manage");
    //        }

    //        //
    //        // POST: /Manage/DisableTwoFactorAuthentication
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<ActionResult> DisableTwoFactorAuthentication()
    //        {
    //            await this.userService.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
    //            var user = await this.userService.FindByIdAsync(User.Identity.GetUserId());
    //            if (user != null)
    //            {
    //                await this.signInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //            }
    //            return RedirectToAction("Index", "Manage");
    //        }

    //        //
    //        // GET: /Manage/VerifyPhoneNumber
    //        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
    //        {
    //            var code = await this.userService.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
    //            // Send an SMS through the SMS provider to verify the phone number
    //            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
    //        }

    //        //
    //        // POST: /Manage/VerifyPhoneNumber
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
    //        {
    //            if (!ModelState.IsValid)
    //            {
    //                return View(model);
    //            }
    //            var result = await this.userService.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
    //            if (result.Succeeded)
    //            {
    //                var user = await this.userService.FindByIdAsync(User.Identity.GetUserId());
    //                if (user != null)
    //                {
    //                    await this.signInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //                }
    //                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
    //            }
    //            // If we got this far, something failed, redisplay form
    //            ModelState.AddModelError("", "Failed to verify phone");
    //            return View(model);
    //        }

    //        //
    //        // POST: /Manage/RemovePhoneNumber
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<ActionResult> RemovePhoneNumber()
    //        {
    //            var result = await this.userService.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
    //            if (!result.Succeeded)
    //            {
    //                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
    //            }
    //            var user = await this.userService.FindByIdAsync(User.Identity.GetUserId());
    //            if (user != null)
    //            {
    //                await this.signInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //            }
    //            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
    //        }

    //        //
    //        // GET: /Manage/ChangePassword
    //        public ActionResult ChangePassword()
    //        {
    //            return View();
    //        }

    //        //
    //        // POST: /Manage/ChangePassword
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
    //        {
    //            if (!ModelState.IsValid)
    //            {
    //                return View(model);
    //            }
    //            var result = await this.userService.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
    //            if (result.Succeeded)
    //            {
    //                var user = await this.userService.FindByIdAsync(User.Identity.GetUserId());
    //                if (user != null)
    //                {
    //                    await this.signInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //                }
    //                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
    //            }
    //            AddErrors(result);
    //            return View(model);
    //        }

    //        //
    //        // GET: /Manage/SetPassword
    //        public ActionResult SetPassword()
    //        {
    //            return View();
    //        }

    //        //
    //        // POST: /Manage/SetPassword
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                var result = await this.userService.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
    //                if (result.Succeeded)
    //                {
    //                    var user = await this.userService.FindByIdAsync(User.Identity.GetUserId());
    //                    if (user != null)
    //                    {
    //                        await this.signInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //                    }
    //                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
    //                }
    //                AddErrors(result);
    //            }

    //            // If we got this far, something failed, redisplay form
    //            return View(model);
    //        }

    //        //
    //        // GET: /Manage/ManageLogins
    //        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
    //        {
    //            ViewBag.StatusMessage =
    //                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
    //                : message == ManageMessageId.Error ? "An error has occurred."
    //                : "";
    //            var user = await this.userService.FindByIdAsync(User.Identity.GetUserId());
    //            if (user == null)
    //            {
    //                return View("Error");
    //            }
    //            var userLogins = await this.userService.GetLoginsAsync(User.Identity.GetUserId());
    //            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
    //            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
    //            return View(new ManageLoginsViewModel
    //            {
    //                CurrentLogins = userLogins,
    //                OtherLogins = otherLogins
    //            });
    //        }

    //        //
    //        // POST: /Manage/LinkLogin
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public ActionResult LinkLogin(string provider)
    //        {
    //            // Request a redirect to the external login provider to link a login for the current user
    //            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
    //        }

    //        //
    //        // GET: /Manage/LinkLoginCallback
    //        public async Task<ActionResult> LinkLoginCallback()
    //        {
    //            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
    //            if (loginInfo == null)
    //            {
    //                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
    //            }
    //            var result = await this.userService.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
    //            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
    //        }

    //        protected override void Dispose(bool disposing)
    //        {
    //            if (disposing && this.userService != null)
    //            {
    //                this.userService.Dispose();
    //            }

    //            base.Dispose(disposing);
    //        }

    //#region Helpers
    //        // Used for XSRF protection when adding external logins
    //        private const string XsrfKey = "XsrfId";

    //        private IAuthenticationManager AuthenticationManager
    //        {
    //            get
    //            {
    //                return HttpContext.GetOwinContext().Authentication;
    //            }
    //        }

    //        private void AddErrors(IdentityResult result)
    //        {
    //            foreach (var error in result.Errors)
    //            {
    //                ModelState.AddModelError("", error);
    //            }
    //        }

    //        private bool HasPassword()
    //        {
    //            var user = this.userService.FindById(User.Identity.GetUserId());
    //            if (user != null)
    //            {
    //                return user.PasswordHash != null;
    //            }
    //            return false;
    //        }

    //        private bool HasPhoneNumber()
    //        {
    //            var user = this.userService.FindById(User.Identity.GetUserId());
    //            if (user != null)
    //            {
    //                return user.PhoneNumber != null;
    //            }
    //            return false;
    //        }

    //        public enum ManageMessageId
    //        {
    //            AddPhoneSuccess,
    //            ChangePasswordSuccess,
    //            SetTwoFactorSuccess,
    //            SetPasswordSuccess,
    //            RemoveLoginSuccess,
    //            RemovePhoneSuccess,
    //            Error
    //        }

    //#endregion
    //    }
}