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
        private readonly BL bl;
        EncryptDecrypt sec = new EncryptDecrypt();
        public AccountController()
        {
            if (SessionUserData.UserCode > 0)
            {
                bl = new BL(Util.GetDbConnString(sec.Encrypt(SessionUserData.Acccode.ToString())));
            }
            else
            {
                bl = new BL(Util.GetDbConnString("catalog"));
            }
        }
        [HttpGet]
        [AllowAnonymous]
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
                    UserModel User = new UserModel
                    {
                        Subcode = resp.Subcode,
                        PhoneNo = resp.PhoneNo,
                        Email = resp.Email,
                        Fullname = resp.Fullname,
                        Acccode = resp.Subcode,
                        connstring = resp.Fullname,
                        Reportstring = resp.Fullname
                    };
                    SetUserLoggedIn(User, false);
                    if (User.Loginstatus == 1)
                    {
                        return RedirectToAction("Subscribe", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
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

        private async void SetUserLoggedIn(UserModel user, bool rememberMe)
        {
            UserDataModel serializeModel = new UserDataModel
            {
                UserCode = user.Subcode,
                Fullname = user.Fullname,
                UserName = user.Email,
                Phonenumber = user.PhoneNo,
                Acccode = user.Parentcode,
                connstring = user.Fullname,
                Reportstring = user.Fullname
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
                IsPersistent = rememberMe,
                ExpiresUtc = new DateTimeOffset?(DateTime.UtcNow.AddMinutes(30))
            });
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(AccountController.Login), "Account");
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

    }
}
