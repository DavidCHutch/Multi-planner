using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace Multi_Planner.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog log;

        public HomeController(ILog _log)
        {
            log = _log;
        }

        public async Task<IActionResult> Index()
        {
            return Json("Home");
        }

        [Route("api/Exception")]
        [Route("Crash")]
        [Route("CrashTest")]
        public async Task<IActionResult> TestException()
        {
            int i = 0;
            int n = 1 / i;

            return Json("No Exceptions!");
        }
    }
}