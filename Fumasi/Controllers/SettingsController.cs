using DBL;
using DBL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fumasi.Controllers
{
    [Authorize]
    public class SettingsController : BaseController
    {
        private TenantBL bl;
        EncryptDecrypt sec = new EncryptDecrypt();
        public SettingsController()
        {
            bl = new TenantBL(Util.GetDbConnString());
        }


        #region Loyaty General Settings
        public IActionResult Loyaltysettings()
        {
            return View();
        }
        #endregion
    }
}
