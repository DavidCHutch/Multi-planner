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

        public Task<bool> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginFacebook(string userId, string accessToken)
        {
            var isAuthentic = await _fService.AuthenticateToken(accessToken, userId);

            if (isAuthentic)
            {
                // TODO merge this into the create method and remove this call.
                User user = await _uService.GetUserByFacebookId(userId);

                if (user == null)
                {
                    user = await _uService.CreateFacebookUser(userId, accessToken);

                    if (user == null)
                        return false;
                }
                else
                    return false;

                user.LastLogin = DateTime.Now;

                //TODO Should be done properly, not with a Mock
                MockDB.GetInstance().UpdateUser(user);

                return true; ;
            }
            else
                return false;
        }
    }
}
