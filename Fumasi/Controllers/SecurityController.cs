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
    public class SecurityController : BaseController
    {
        private GeneralBL bl;
        private TenantBL bl1;
        EncryptDecrypt sec = new EncryptDecrypt();
        public SecurityController()
        {
            bl = new GeneralBL(Util.GetDbConnString());
        }

        #region Staffs Roles
        [HttpGet]
        public async Task<IActionResult> Roleslist()
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Addnewrole()
        {
            Staffroles data = new Staffroles();
            try{
                data.permissions = await bl.Getpermissionsdata();
            }catch (Exception ex)
            {
                Util.LogError("Add New Role",ex,true);
            }
            return View(data);
        }
        
        #endregion
        #region Staffs 
        [HttpGet]
        public async Task<IActionResult> Staffslist()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddnewStaff()
        {
            LoadParams();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddnewStaff(Tenantstaffs model)
        {
            LoadParams();
            try
            {
                if (ModelState.IsValid)
                {
                    model.Modifiedby = SessionUserData.UserName;
                    model.Createdby = SessionUserData.UserName;
                    model.Tenantcode = SessionUserData.UserCode;
                    model.Datecreated = DateTime.UtcNow;
                    model.Datemodified = DateTime.UtcNow;
                    var resp = await bl.Addnewtenantstaff(model);
                    if (resp.RespStatus == 0)
                    {
                        Success(resp.RespMessage, true);
                        return RedirectToAction("Staffslist", "Security");
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
                Util.LogError("Add Staff", ex,true);
            }
            return View();
        }
        #endregion


        #region Other methods
        private void LoadParams()
        {
            bl1 = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            var list = bl1.GetListModel(ListModelType.staffroles).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["staffroles"] = list;
            list = bl1.GetListModel(ListModelType.tenantstations).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["tenantstations"] = list;
        }
        #endregion
    }
}
