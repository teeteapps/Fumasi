using DBL;
using DBL.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fumasi.Controllers
{
    public class StaffController : BaseController
    {
        private readonly BL bl;
        EncryptDecrypt sec = new EncryptDecrypt();
        public StaffController()
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
        public IActionResult Stafflist()
        {
            return View();
        }
    }
}
