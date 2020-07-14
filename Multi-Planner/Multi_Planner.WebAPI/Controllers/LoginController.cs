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
using Multi_Planner.DataModel.ViewModels;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Extensions.DependencyInjection;

namespace Multi_Planner.WebAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILog Log;
        private readonly ILoginService _lService;
        private readonly IUserService _uService;

        public LoginController(ILog log, ILoginService lService, IUserService uService)
        {
            Log = log;
            _lService = lService;
            _uService = uService;
        }

        [HttpPost]
        [Route("api/Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel lvm)
        {
            Log.Info("Login flow started");

            //validate
            if (string.IsNullOrEmpty(lvm.email) || string.IsNullOrEmpty(lvm.password))
            {
                string msg = "Missing Parameters";
                Log.Warn(msg);
                return BadRequest(msg);
            }

            //Act
            //User user = await _lService.Login(lvm.email, lvm.password);
            User user = null;
            if (user == null)
            {
                string msg = "Could not log user in.";
                Log.Warn(msg);
                return BadRequest(msg) ;
            }

            var response = new LoginResponseViewModel(user);

            //Response
            Log.Info("Login flow Succes");
            return Ok(response);
        }

        [HttpPost]
        [Route("api/Login/Facebook")]
        public async Task<IActionResult> LoginFacebook([FromBody] FacebookLoginViewModel flvm)
        {
            Log.Info("Facebook login flow started");

            if (string.IsNullOrEmpty(flvm.userid) || string.IsNullOrEmpty(flvm.firstName))
            {
                return BadRequest("Missing Parameters");
            }

            User user = await _lService.LoginFacebook(flvm.userid);

            if (string.IsNullOrEmpty(user.FirstName))
            {
                //TODO handle this in another way.
                //used to catch cast errors in .LoginFacebook
                return BadRequest("Could not log facebook user in.");
            }
            else if (user != null)
            {
                // user exists
                return Ok("Facebook user was logged in.") ;
            }

            //User doesnt exist, create it.
            user = await _uService.CreateFacebookUser(flvm.userid, flvm.firstName);

            if (user == null)
            {
                string msg = "Could not create facebook user.";
                Log.Warn(msg);
                return BadRequest(msg);
            }

            //Response
            Log.Info("Login flow Succes");
            return Ok("Facebook user was created and logged in.");

        }
    }
}