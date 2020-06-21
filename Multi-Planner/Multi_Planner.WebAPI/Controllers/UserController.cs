using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Multi_Planner.Services;
using Multi_Planner.Services.Interfaces;
using Multi_Planner.DataModel;
using Multi_Planner.DataModel.ViewModels;

namespace Multi_Planner.WebAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILog Log;
        private readonly IUserService _uService;

        public UserController(ILog log, IUserService uService)
        {
            Log = log;
            _uService = uService;
        }

        [HttpPost]
        [Route("api/User/Create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserViewModel cuvm)
        {
            Log.Info("Create user flow initiated");

            //Validate
            if (cuvm == null || string.IsNullOrEmpty(cuvm.firstName) || string.IsNullOrEmpty(cuvm.lastName) || string.IsNullOrEmpty(cuvm.lastName))
            {
                string msg = "One or more values are not set.";
                Log.Warn(msg);
                return BadRequest(new ErrorViewModel() { Message = msg});
            }
            
            //Act
            User user = await _uService.CreateUser(cuvm.firstName, cuvm.lastName, cuvm.email, cuvm.password);

            if (user == null)
            {
                string msg = "Could not create user.";
                Log.Warn(msg);
                return BadRequest(new ErrorViewModel() { Message = msg });
            }

            var response = new CreateUserResponseViewModel();

            //Response
            Log.Info("Create User flow Succes");
            return Json(response);
        }


    }
}
