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
        private readonly IFacebookService fbService;

        string FacebookRedirectUri = "api/Facebook/Redirect";

        public LoginController(ILoginService _lService, IFacebookService _fbService)
        {
            lService = _lService;
            fbService = _fbService;
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
        public async Task<IActionResult> ConnectFacebook() 
        {
            var redirectUri = $"{this.Request.Scheme}://{Request.Host}" + FacebookRedirectUri;

            var result = await fbService.GetLoginUrl(new Uri(redirectUri));

            if (result.Status == ServiceResponseStatus.Ok)
            {
                return Json(result.Result);
            }
            else
            {
                //TODO Log error.
                return NotFound();
            }
        }

        //Both Redirect endpoints need to have the same route. If the rounte is changed, then 'FacebookRedirect' field needs to be updated
        [HttpGet]
        [Route("api/Facebook/Redirect")]
        public async Task FacebookLoginRedirect(string code, string state)
        {
            var redirectUri = $"{this.Request.Scheme}://{Request.Host}" + FacebookRedirectUri;

            await fbService.GetAccessToken(code, new Uri(redirectUri));

            //TODO Handle canceled login and errors.
        }

        //Both Redirect endpoints need to have the same route. If the rounte is changed, then 'FacebookRedirect' field needs to be updated
        [HttpGet]
        [Route("api/Facebook/Redirect")]
        public async Task FacebookTokenRedirect([FromBody] FacebookAccessToken token)
        {
            await fbService.SaveToken(token);
        }
    }
}