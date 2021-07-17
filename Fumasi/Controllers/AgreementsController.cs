using DBL;
using DBL.Entities;
using DBL.Enum;
using DBL.Helpers;
using DBL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fumasi.Controllers
{
    [Authorize]
    public class AgreementsController : BaseController
    {
        private TenantBL bl;
        EncryptDecrypt sec = new EncryptDecrypt();

        public IActionResult Oneoffagreement(string customercode)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            Customeroneoffagreement model = new Customeroneoffagreement();
            model.Custcode = Convert.ToInt64(sec.Decrypt(customercode));
            return PartialView("_Oneoffagreement", model);
        }
        [HttpGet]
        public IActionResult Recurrentagreement(string customercode)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            Customerrecurrentagreement model = new Customerrecurrentagreement();
            model.Custcode = Convert.ToInt64(sec.Decrypt(customercode));
            return PartialView("_Recurrentagreement", model);
        }

        [HttpGet]
        public IActionResult Prepaidagreement(string Code)
        {
            LoadParams();
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            Customerprepaidagreement model = new Customerprepaidagreement();
            model.Customercode = Convert.ToInt64(sec.Decrypt(Code));
            return PartialView("_Addprepaidagreement", model);
        }
        [HttpPost]
        public async Task<IActionResult> Addprepaidagreement(Customerprepaidagreement model)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            try
            {
                var fileName = "";
                var filepath = "";
                var newFileName = "";
                string uploadPath = "~/Agreementdocuments/";
                if (model.Agreementfile !=null)
                {
                    //Getting FileName
                    fileName = Path.GetFileName(model.Agreementfile.FileName);

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);

                    // concatenating  FileName + FileExtension
                    newFileName = String.Concat(myUniqueFileName, fileExtension);

                    // Combines two strings into a path.
                    filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Docs")).Root + $@"\{newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        model.Agreementfile.CopyTo(fs);
                        fs.Flush();
                    }
                    var uploadfilePath = Path.Combine(uploadPath, newFileName);
                    model.Agreementdoc = uploadfilePath;
                }
                model.Modifiedby = SessionUserData.UserCode;
                model.Customercode = model.Customercode;
                model.Createdby = SessionUserData.UserCode;
                model.Datecreated = DateTime.UtcNow;
                model.Datemodified = DateTime.UtcNow;
                var resp = await bl.Addnewprepaidagreement(model);
                if (resp.RespStatus == 0)
                {
                    Success(resp.RespMessage, true);
                    return RedirectToAction("Customerdetails", "Customers", new { customercode = sec.Encrypt(model.Customercode.ToString()) });
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
                Util.LogError("Add new Prepaid Agreement", ex, true);
            }
            return RedirectToAction("Customerdetails", "Customers", new { customercode = sec.Encrypt(model.Customercode.ToString()) });
        }
        
        #region Agreement Account
        [HttpGet]
        public IActionResult Addnewagreementaccount(long Customeragreementid,long Customercode, long Credittype, long Parentcode, long Loyaltycode)
        {
            LoadParams();
            Customeragreementaccount model = new Customeragreementaccount();
            model.Agreementcode = Customeragreementid;
            model.Credittype = Credittype;
            model.Loyaltycode = Loyaltycode;
            model.Customercode = Customercode;
            model.Parentcode = Parentcode;
            return PartialView("_Addnewaccount", model);
        }
        [HttpPost]
        public async Task<IActionResult> Postnewagreementaccount(Customeragreementaccount model)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            try
            {
                
                model.Modifiedby = SessionUserData.UserCode;
                model.Createdby = SessionUserData.UserCode;
                model.Datecreated = DateTime.UtcNow;
                model.Datemodified = DateTime.UtcNow;
                var resp = await bl.Addnewagreementaccount(model);
                if (resp.RespStatus == 0)
                {
                    Success(resp.RespMessage, true);
                   return  RedirectToAction("Customerdetails", "Customers", new { customercode = sec.Encrypt(model.Customercode.ToString()) });
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
                Util.LogError("Add new Prepaid Agreement", ex, true);
            }
            return View();
            // RedirectToAction("Customerdetails", "Customers", new { customercode = sec.Encrypt(model.Customercode.ToString()) });
        }
        #endregion

        #region Customer Agreement Account Details
        public async Task<IActionResult> Agreementaccountdetails(string Code)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            var data = await bl.Getagreementdata(Convert.ToInt64(sec.Decrypt(Code)));
            return View(data);
        }
        public async Task<IActionResult> Getagreementaccounts(long Code)
        
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var accountsdata = await bl.Getagreementaccountsdata(Code);
            List<Vwagreementaccounts> accounts= new List<Vwagreementaccounts>();
            foreach (var item in accountsdata)
            {
                var ca = new Vwagreementaccounts()
                {
                    accountCode = item.accountCode,
                    accountAction = string.Format(@"<a href='/Agreements/Agreementaccountandpolicies?Code={0}'>{1}</a>", sec.Encrypt(item.accountCode.ToString()),item.accountNumber),
                    identifierSno = item.identifierSno,
                    identifierUid = item.identifierUid,
                    accountNumber = item.accountNumber,
                };
                accounts.Add(ca);
            }
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //{
            //    accounts = accounts.OrderBy(sortColumn + " " + sortColumnDirection);
            //}
            if (!string.IsNullOrEmpty(searchValue))
            {
                accounts = accounts.Where(m => m.identifierSno.Contains(searchValue)).ToList();
            }
            recordsTotal = accounts.Count();
            var data = accounts.Skip(skip).Take(pageSize).ToList();
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
        }
        
        #endregion

        #region Account and Policies
        public IActionResult Agreementaccountandpolicies(string Code)
        {
            Customeragreementaccountandpolicies model = new Customeragreementaccountandpolicies();
            model.Acccode = Convert.ToInt64(sec.Decrypt(Code));
            return View(model);
        }
        #region Account Identifiers
        [HttpGet]
        public IActionResult Addnewaccountidentifier(long accntcode)
        {
            LoadParams();
            Customeragreementaccountidentifiers model = new Customeragreementaccountidentifiers();
            model.Accountcode = accntcode;
            return PartialView("_Addnewaccountidentifier", model);
        }
        [HttpPost]
        public async Task<IActionResult> Addnewaccountidentifier(Customeragreementaccountidentifiers model)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            try
            {

                model.Identifieruid = model.Identifiersno;
                model.Modifiedby = SessionUserData.UserName;
                model.Createdby = SessionUserData.UserName;
                model.Datecreated = DateTime.UtcNow;
                model.Datemodified = DateTime.UtcNow;
                var resp = await bl.Addnewaccountidentifier(model);
                if (resp.RespStatus == 0)
                {
                    Success(resp.RespMessage, true);
                    return RedirectToAction("Agreementaccountandpolicies", "Agreements", new { accountcode = sec.Encrypt(model.Accountcode.ToString()) });
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
                Util.LogError("Add New Account Identifier Agreement", ex, true);
            }
            return RedirectToAction("Agreementaccountandpolicies", "Agreements", new { accountcode = sec.Encrypt(model.Accountcode.ToString()) });
        }
        #endregion

        #region Account Employees

        [HttpGet]
        public IActionResult Addnewaccountemployees(long accntcode)
        {
            LoadParams();
            Customeragreementaccountemployees model = new Customeragreementaccountemployees();
            model.Accountcode = accntcode;
            return PartialView("_Addnewaccountemployees", model);
        }
        [HttpPost]
        public async Task<IActionResult> Addnewaccountemployees(Customeragreementaccountemployees model)
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            try
            {
                model.Modifiedby = SessionUserData.UserName;
                model.Createdby = SessionUserData.UserName;
                model.Datecreated = DateTime.UtcNow;
                model.Datemodified = DateTime.UtcNow;
                var resp = await bl.Addnewaccountemployee(model);
                if (resp.RespStatus == 0)
                {
                    Success(resp.RespMessage, true);
                    return RedirectToAction("Agreementaccountandpolicies", "Agreements", new { accountcode = sec.Encrypt(model.Accountcode.ToString()) });
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
                Util.LogError("Add New Account Identifier Agreement", ex, true);
            }
            return RedirectToAction("Agreementaccountandpolicies", "Agreements", new { accountcode = sec.Encrypt(model.Accountcode.ToString()) });
        }
        #endregion
        #region Account Equipment
        [HttpGet]
        public IActionResult Addnewaccountequipments(long accntcode)
        {
            LoadParams();
            Customeragreementaccountequipments model = new Customeragreementaccountequipments();
            model.Accountcode = accntcode;
            return PartialView("_Addnewaccountequipments", model);
        }

        #endregion
        [HttpGet]
        public IActionResult Addnewaccountproductpolicy(long accntcode)
        {
            LoadParams();
            Customeragreementaccountproductpolicy model = new Customeragreementaccountproductpolicy();
            model.Accountcode = accntcode;
            return PartialView("_Addnewaccountproductpolicy", model);
        }
        [HttpGet]
        public IActionResult Addnewaccountstationpolicy(long accntcode)
        {
            LoadParams();
            Customeragreementaccountstationpolicy model = new Customeragreementaccountstationpolicy();
            model.Accountcode = accntcode;
            return PartialView("_Addnewaccountstationpolicy", model);
        }
        [HttpGet]
        public IActionResult Addnewaccountdaypolicy(long accntcode)
        {
            LoadParams();
            Customeragreementaccountdayspolicy model = new Customeragreementaccountdayspolicy();
            model.Accountcode = accntcode;
            return PartialView("_Addnewaccountdaypolicy", model);
        }
        [HttpGet]
        public IActionResult Addnewaccountfrequencypolicy(long accntcode)
        {
            LoadParams();
            Customeragreementaccountfrequencypolicy model = new Customeragreementaccountfrequencypolicy();
            model.Accountcode = accntcode;
            return PartialView("_Addnewaccountfrequencypolicy", model);
        }

        #endregion

        #region Account Employee
        public IActionResult Agreementemployeeandpolicies()
        {
            return View();
        }
        #endregion
        #region Account Equipments
        public IActionResult Agreementequipmentandpolicies()
        {
            return View();
        }
        #endregion

        #region Other methods

        private void LoadParams()
        {
            bl = new TenantBL(Util.GetTenantDbConnString(SessionUserData.connId, SessionUserData.connKey, SessionUserData.connData));
            var list = bl.GetListModel(ListModelType.identifiers).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["identifiers"] = list;

            list = bl.GetListModel(ListModelType.identifiertypes).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["identifiertypes"] = list;
            list = bl.GetListModel(ListModelType.limittypes).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["limittypes"] = list;
            list = bl.GetListModel(ListModelType.limittypes).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["limittypes"] = list;
            list = bl.GetListModel(ListModelType.pricelist).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["pricelist"] = list;
            list = bl.GetListModel(ListModelType.discountlist).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["discountlist"] = list;
            list = bl.GetListModel(ListModelType.Loyaltylist).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["Loyaltylist"] = list;
        }
        #endregion
    }
}
