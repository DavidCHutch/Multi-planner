using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multi_Planner.Services.Interfaces;
using Multi_Planner.DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using log4net;

namespace Multi_Planner.WebAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILog Log;
        private readonly ILoginService _lService;

        public LoginController(ILog log, ILoginService lService)
        {
            _lService = lService;
            Log = log;
        }

        [HttpGet]
        [Route("api/Login")]
        public async Task<IActionResult> Login(string username = "", string password = "")
        {
            string loginRes = "Empty";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                loginRes = "Username or Password is empty";
            }
            else
            {
                var result = await lService.Login(username, password);

                loginRes = "Login " + (result ? "succesful" : "failed");
           }

            return Json(loginRes);
        }

        [HttpGet]
        [Route("api/Login/Facebook")]
        public async Task<IActionResult> LoginFacebook(string userid, string accessToken)
        {
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(accessToken))
            {
                return BadRequest("Missing Parameters");
            }
            else
            {
                bool succes = await lService.LoginFacebook(userid, accessToken);

                if(succes)
                    return Ok();
                else
                    return BadRequest();
            }
        }
    }
}