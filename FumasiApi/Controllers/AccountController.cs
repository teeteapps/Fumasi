using DBL;
using DBL.Entities;
using DBL.Helpers;
using FumasiApi.Models;
using FumasiApi.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FumasiApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly GeneralBL bl;
        EncryptDecrypt sec = new EncryptDecrypt();
        public AccountController()
        {
            bl = new GeneralBL(Util.GetDbConnString());
        }
        [HttpPost]
        [Route("Username={Username}/Password={Password}")]
        public async Task<IActionResult> Login(string Username,string Password)
        {
            GenericModelResp login =new GenericModelResp();
            var resp = await bl.Login(Username, Password);
            if (resp.RespStatus == 0)
            {
                login.RespStatus = 200;
                login.RespMessage = "Login Successful";
                return new ObjectResult(login);
            }
            else if (resp.RespStatus == 1)
            {
                login.RespStatus = 300;
                login.RespMessage = resp.RespMessage;
                return new ObjectResult(login);
            }
            else
            {
                login.RespStatus = 500;
                login.RespMessage = "A database error occured. Contact Admin!";
                return new ObjectResult(login);
            }
        }

    }
}
