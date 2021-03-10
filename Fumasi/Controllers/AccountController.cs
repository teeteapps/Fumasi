using DBL;
using DBL.Helpers;
using DBL.Models;
using Fumasi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fumasi.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly GeneralBL bl;
        EncryptDecrypt sec = new EncryptDecrypt();        
        public AccountController()
        {
            bl = new GeneralBL(Util.GetDbConnString());
        }
        #region Login
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Loginviewmodel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var resp = await bl.Login(model.Emailaddress, model.Password);
                if (resp.RespStatus == 0)
                {
                    UserModel User = new UserModel();

                    User.Subcode = resp.Subcode;
                    User.PhoneNo = resp.PhoneNo;
                    User.Email = resp.Email;
                    User.Fullname = resp.Fullname;
                    User.profilecode = resp.profilecode;
                    User.connId = resp.connId;
                    User.connKey = resp.connKey;
                    User.connData = resp.connData;
                    SetUserLoggedIn(User);
                    //Viewer Profile
                    return RedirectToLocal(returnUrl);
                }
                else if (resp.RespStatus == 1)
                {
                    Danger(resp.RespMessage, true);
                }
                else
                {
                    Danger("Database Error Occured. Contact Admin!", true);
                }
            }
            return View(new Loginviewmodel());
        }

        private async void SetUserLoggedIn(UserModel user)
        {
            UserDataModel serializeModel = new UserDataModel
            {
                UserCode = user.Subcode,
                Fullname = user.Fullname,
                UserName = user.Email,
                Phonenumber = user.PhoneNo,
                ProfileCode = user.profilecode,
                connId =user.connId,
                connKey =user.connKey,
                connData =user.connData
            };

            string userData = JsonConvert.SerializeObject(serializeModel);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Subcode.ToString()),
                new Claim(ClaimTypes.Name, user.Fullname),
                 new Claim("FullNames", serializeModel.Fullname),
                new Claim("userData", userData),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie");

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity[] { claimsIdentity });
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
            new AuthenticationProperties
            {
                IsPersistent = false,
                ExpiresUtc = new DateTimeOffset?(DateTime.UtcNow.AddMinutes(30))
            });
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Dashboard), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Dashboard), "Home");
        }
        #endregion

        [AllowAnonymous]
        public IActionResult Forgotpassword()
        {
            return View();
        }
    }
}
