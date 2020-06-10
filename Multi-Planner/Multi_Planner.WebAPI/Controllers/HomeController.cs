using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Multi_Planner.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return Json("Home");
        }

        [Route("api/Exception/Catch")]
        public async Task<IActionResult> TestExceptionCatch()
        {
            try
            {
                int i = 0;
                int n = 1 / i;
            }
            catch (Exception)
            {
                return Json("Exception catched");
            }
            return Json("Exception NOT catched");
        }

        [Route("api/Exception")]
        public async Task<IActionResult> TestException()
        {
            int i = 0;
            int n = 1 / i;

            return Json("No Exceptions!");
        }
    }
}