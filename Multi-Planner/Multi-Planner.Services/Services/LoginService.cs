using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Multi_Planner.DataModel;
using Multi_Planner.Services.Interfaces;
using Multi_Planner.Services;
using System.Runtime.InteropServices.ComTypes;

namespace Multi_Planner.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly MockDB db;
        private readonly IUserService _uService;
        private readonly IFacebookService _fService;

        public LoginService(
            IUserService uService,
            IFacebookService fService)
        {
            db = MockDB.GetInstance();
            _uService = uService;
            _fService = fService;
        }

        public async Task<ServiceResponse<bool>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> LoginFacebook(string userId, string accessToken)
        {
            var fResult = await _fService.AuthenticateToken(accessToken, userId);

            if (fResult.Status != ServiceResponseStatus.Ok)
            {
                return new ServiceResponse<bool>(fResult.Status, fResult.Message, false);
            }

            if (fResult.Result)
            {
                var uResult = await _uService.GetUserByFacebookId(userId);

                if (uResult.Status != ServiceResponseStatus.Ok)
                {
                    return new ServiceResponse<bool>(uResult.Status, uResult.Message, false);
                }

                User user = uResult.Result;

                if (user == null)
                {
                    var createResult = await _uService.CreateFacebookUser(userId, accessToken);

                    if (createResult.Status != ServiceResponseStatus.Ok)
                    {
                        return new ServiceResponse<bool>(ServiceResponseStatus.Error, "Could not create user. \n" + createResult.Message, false);
                    }

                    user = createResult.Result;
                }

                user.LastLogin = DateTime.Now;

                //TODO Should be done properly throught the user service
                MockDB.GetInstance().UpdateUser(user);

                return new ServiceResponse<bool>(ServiceResponseStatus.Ok, true); ;
            }
            else
            {
                return new ServiceResponse<bool>(ServiceResponseStatus.Error, "Could not authenticate token", false);
            }
        }
    }
}
