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
    public class PricesController : BaseController
    {
        private TenantBL bl;
        EncryptDecrypt sec = new EncryptDecrypt();

        [HttpGet]
        public async Task<IActionResult> Pricelist()
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            IEnumerable<Pricelists> data = new List<Pricelists>();
            try
            {
                data = await bl.Gettenantpricelists();
            }
            catch (Exception ex)
            {
                Util.LogError("Get Customer Data", ex, true);
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Addnewprice()
        {
            return PartialView("_Addnewprice");
        }
        [HttpPost]
        public async Task<IActionResult> Addnewprice(Pricelists model)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            try
            {
                model.Modifiedby = SessionUserData.UserCode;
                model.Createdby = SessionUserData.UserCode;
                model.Datecreated = DateTime.UtcNow;
                model.Datemodified = DateTime.UtcNow;
                var resp = await bl.Addnewprice(model);
                if (resp.RespStatus == 0)
                {
                    Success(resp.RespMessage, true);
                    return RedirectToAction("Pricelist", "Prices");
                }
                else if (resp.RespStatus == 1)
                {
                    Danger(resp.RespMessage, true);
                }
                else
                {
                    Danger("Database Error Occured. Please Contact Admin", true);
                }
            }
            catch (Exception ex)
            {
                Util.LogError("Add New Price", ex, true);
            }
            return RedirectToAction("Pricelist", "Prices");
        }
        [HttpGet]
        public async Task<IActionResult> Editnewprice(string Code)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            var data = await bl.Gettenantpricedata(Convert.ToInt64(sec.Decrypt(Code)));
            return PartialView("_Editnewprice",data);
        }
        [HttpPost]
        public async Task<IActionResult> Editnewprice(Pricelists model)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            try
            {
                model.Modifiedby = SessionUserData.UserCode;
                model.Datemodified = DateTime.UtcNow;
                var resp = await bl.Editnewprice(model);
                if (resp.RespStatus == 0)
                {
                    Success(resp.RespMessage, true);
                    return RedirectToAction("Pricelist", "Prices");
                }
                else if (resp.RespStatus == 1)
                {
                    Danger(resp.RespMessage, true);
                }
                else
                {
                    Danger("Database Error Occured. Please Contact Admin", true);
                }
            }
            catch (Exception ex)
            {
                Util.LogError("Edit New Price", ex, true);
            }
            return RedirectToAction("Pricelist", "Prices");
        }
        [HttpGet]
        public async Task<IActionResult> Pricedetails(string Code)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            var data = await bl.Gettenantpricedata(Convert.ToInt64(sec.Decrypt(Code)));
            return View(data);
        }
        public IActionResult Addnewpricelistprice(string Code)
        {
            Pricelistprices model = new Pricelistprices();
            model.Pricecode = Convert.ToInt64(sec.Decrypt(Code));
            return PartialView("_Addnewpricelistprice", model);
        }
    }
}
