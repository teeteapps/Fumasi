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
    public class ProductsController : Controller
    {
        private TenantBL bl;
        EncryptDecrypt sec = new EncryptDecrypt();
        public ProductsController()
        {
            bl = new TenantBL(Util.GetDbConnString());
        }


        [HttpGet]
        public IActionResult Productslist()
        {
            return View();
        }
    }
}
