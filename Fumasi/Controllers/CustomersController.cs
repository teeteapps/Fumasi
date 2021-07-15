using DBL;
using DBL.Entities;
using DBL.Enum;
using DBL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fumasi.Controllers
{
    [Authorize]
    public class CustomersController : BaseController
    {
        private TenantBL bl;
        EncryptDecrypt sec = new EncryptDecrypt();

        [HttpGet]
        public async Task<IActionResult> Customerslist()
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            IEnumerable<Vwtenantcustomers> data = new List<Vwtenantcustomers>();
            try
            {
                data = await bl.Getcustomersdata();
            }
            catch (Exception ex)
            {
                Util.LogError("Get Customer Data",ex,true);
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult AddnewCustomers()
        {
            LoadParams();
            return PartialView("_AddnewCustomers");
        }

        [HttpPost]
        public async Task<IActionResult> AddnewCustomers(Customers model)
        {
            LoadParams();
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
                        var resp = await bl.AddnewCustomers(model);
                        if (resp.RespStatus == 0)
                        {
                            Success(resp.RespMessage, true);
                            return RedirectToAction("Customerdetails", "Customers",new {customercode=sec.Encrypt(resp.Data7) });
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
            }
            catch (Exception ex)
            {
                Util.LogError("Add New Customer",ex,true);
            }
            return RedirectToAction("Customerslist");
        }

        [HttpGet]
        public async Task<IActionResult> Customerdetails(string customercode)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            Customerandagreementdetails data = new Customerandagreementdetails();
            data.customers = new Vwtenantcustomers();
            data.prepaidagreement = new List<Customerprepaidagreementdata>();
            try 
            {
                data.customers = await bl.Gettenantcustomerdata(Convert.ToInt64(sec.Decrypt(customercode)));
                data.prepaidagreement = await bl.Gettenantcustomerprepaidagreementdata(Convert.ToInt64(sec.Decrypt(customercode)));
            }
            catch (Exception ex)
            {
                Util.LogError("Customer Details Data",ex,true);
            }
            return View(data);
        }


        #region Other methods
        private void LoadParams()
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            var list = bl.GetListModel(ListModelType.tenantstations).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["tenantstations"] = list;
        }
        #endregion
    }
}
