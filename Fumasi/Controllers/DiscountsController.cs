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
        [HttpGet]
        public IActionResult Addnewdiscount()
        {
            return PartialView("_Addnewdiscount");
        }
        [HttpPost]
        public async Task<IActionResult> Addnewdiscount(Discountlist model)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            try
            {
                model.Modifiedby = SessionUserData.UserCode;
                model.Createdby = SessionUserData.UserCode;
                model.Datecreated = DateTime.UtcNow;
                model.Datemodified = DateTime.UtcNow;
                var resp = await bl.Addnewdiscount(model);
                if (resp.RespStatus == 0)
                {
                    Success(resp.RespMessage, true);
                    return RedirectToAction("Discountlist", "Discounts");
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
                Util.LogError("Add New Discount", ex, true);
            }
          return RedirectToAction("Discountlist", "Discounts");
        }
        [HttpGet]
        public async Task<IActionResult> Editnewdiscount(string Code)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            var data = await bl.Gettenantdiscountdata(Convert.ToInt64(sec.Decrypt(Code)));
            return PartialView("_Editnewdiscount", data);
        }
        [HttpPost]
        public async Task<IActionResult> Editnewdiscount(Discountlist model)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            try
            {
                model.Modifiedby = SessionUserData.UserCode;
                model.Datemodified = DateTime.UtcNow;
                var resp = await bl.Editnewdiscount(model);
                if (resp.RespStatus == 0)
                {
                    Success(resp.RespMessage, true);
                    return RedirectToAction("Discountlist", "Discounts");
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
                Util.LogError("Edit New Discount", ex, true);
            }
            return RedirectToAction("Discountlist", "Discounts");
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
