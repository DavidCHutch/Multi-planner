using Multi_Planner.DataModel;
using Multi_Planner.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Planner.Services.Services
{
    public class UserService : IUserService
    {
        public async Task<User> CreateFacebookUser(string userId, string accessToken)
        {
            //TODO get info from facebook service
            User user = new User()
            {
                FacebookUserID = userId,
                FacebookAcessToken = new FacebookUserToken(accessToken, 0)// TODO get expiration date...
            };

            MockDB.GetInstance().SaveUser(user);

            return user;
        }

        public async Task<User> GetUserByFacebookId(string userId)
        {
            User user;
            int count; // Purly for dev purpose. Remove this before release.
            
            (user, count) = MockDB.GetInstance().RetrieveUserByFacebookId(userId);

            return user;
        }
    }
}
