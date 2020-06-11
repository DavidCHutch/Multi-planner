using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multi_Planner.Services.Interfaces;
using Multi_Planner.DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

namespace Multi_Planner.WebAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService lService;

        public LoginController(ILoginService _lService)
        {
            lService = _lService;
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

                loginRes = "Login " + (result.Result ? "succesful" : "failed");
            }

            return Json(loginRes);
        }

        [HttpGet]
        [Route("api/Login/Facebook")]
        [DisableCors]
        public async Task<IActionResult> LoginFacebook(string userid, string accessToken)
        {
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(accessToken))
            {
                return BadRequest("Missing Parameters");
            }
            else
            {
                var serviceResult = await lService.LoginFacebook(userid, accessToken);

                switch (serviceResult.Status)
                {
                    case ServiceResponseStatus.Ok:
                        return Ok();
                    default:
                        return BadRequest();
                }
            }
        }
    }
}