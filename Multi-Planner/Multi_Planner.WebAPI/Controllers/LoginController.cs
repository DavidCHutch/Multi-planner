using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multi_Planner.Services.Interfaces;
using Multi_Planner.Services.Services;
using Multi_Planner.DataModel;

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
    }
}