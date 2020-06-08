using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multi_Planner.Services.Interfaces;
using Multi_Planner.Services.Services;

namespace Multi_Planner.WebAPI.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _lService;

        public LoginController(ILoginService lService)
        {
            _lService = lService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string username = "", string password = "")
        {
            string loginRes = "Empty";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                loginRes = "Username or Password is empty";
            }
            else
            {
                var result = await _lService.Login(username, password);

                loginRes = "Login " + (result ? "succesful" : "failed");
            }

            return Json(loginRes);
        }
    }
}