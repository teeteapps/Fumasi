using DBL;
using DBL.Entities;
using DBL.Helpers;
using DBL.Models;
using Fumasi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fumasi.Controllers
{
    [Authorize]
    public class StationsController : BaseController
    {
        private  TenantBL bl;
        EncryptDecrypt sec = new EncryptDecrypt();

        DateTimeWithZone date = new DateTimeWithZone();
        #region Tenant Stations

        [HttpGet]
        public async Task<IActionResult> Stationslist()
        {
            IEnumerable<Stations> data = new List<Stations>();
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId,SessionUserData.connKey,SessionUserData.connData));
            try
            {
                data = await bl.Gettenenatstationslist();
            }
            catch (Exception ex)
            {
                Util.LogError("Tenant Station List",ex,true);
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Addnewstation()
        {
            try
            {

            }catch(Exception ex)
            {
                Util.LogError("Add new station", ex,true);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Addnewstation(Stations model)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            try
            {
                if (ModelState.IsValid)
                {
                    model.Modifiedby = SessionUserData.UserName;
                    model.Createdby = SessionUserData.UserName;
                    model.Tenantcode = SessionUserData.UserCode;
                    model.Datecreated = DateTime.UtcNow;
                    model.Datemodified = DateTime.UtcNow;
                    var resp = await bl.Addnewtenantstation(model);
                    if (resp.RespStatus==0)
                    {
                        Success(resp.RespMessage,true);
                        return RedirectToAction("Stationdetails", "Stations", new { Stationcode = sec.Encrypt(resp.Data1) });
                    }else if (resp.RespStatus==1)
                    {
                        Danger(resp.RespMessage,true);
                    }
                    else
                    {
                        Danger("Database Error Occured. Please Contact Admin", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Util.LogError("Add new station", ex, true);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Stationdetails(string Stationcode)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            Stations data = new Stations();
            try
            {
               data = await bl.GetStationdetaildata(Convert.ToInt64(sec.Decrypt(Stationcode)));
            }
            catch (Exception ex)
            {
                Util.LogError("Station Details",ex,true);
            }
            return View(data);
        }
        #endregion
    }
}
