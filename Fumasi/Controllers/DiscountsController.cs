using DBL;
using DBL.Entities;
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
    public class DiscountsController : BaseController
    {
        private TenantBL bl;
        EncryptDecrypt sec = new EncryptDecrypt();
        public async Task<IActionResult> Discountlist()
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            IEnumerable<Discountlist> data = new List<Discountlist>();
            try
            {
                data = await bl.Gettenantdiscountlists();
            }
            catch (Exception ex)
            {
                Util.LogError("Get Customer Data", ex, true);
            }
            return View(data);
        }
    }
}
