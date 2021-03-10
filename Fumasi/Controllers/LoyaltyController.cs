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
    public class LoyaltyController : BaseController
    {
     

        #region Loyalty Conversions
        public IActionResult Loyaltyconversions()
        {
            return View();
        }
        #endregion
        #region Loyalty Formulas
        public IActionResult Formulalist()
        {
            return View();
        }
        #endregion
        #region Loyalty Schemes
        public IActionResult Schemeslist()
        {
            return View();
        }
        #endregion
    }
}
