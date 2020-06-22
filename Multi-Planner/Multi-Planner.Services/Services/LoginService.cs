using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Multi_Planner.DataModel;
using Multi_Planner.Services.Interfaces;
using Multi_Planner.Services;
using System.Runtime.InteropServices.ComTypes;
using log4net;
using System.Linq;

namespace Multi_Planner.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILog Log;
        private readonly IMongoService _dbService;
        private readonly IUserService _uService;
        private readonly IFacebookService _fService;

        public LoginService(
            ILog log,
            IMongoService dbService,
            IUserService uService,
            IFacebookService fService)
        {
            Log = log;
            _dbService = dbService;
            _uService = uService;
            _fService = fService;
        }

        public async Task<User> Login(string email, string password)
        {
            var items = await _dbService.FindItems(Collections.Users, "email", email);

            if (items.Count > 1)
                Log.Error("Found several ambigous results when looking for users!");

            var item = items.FirstOrDefault();

            if (item == null)
            {
                Log.Info("Found no users to log in");
                return null;
            }

            string value = item.GetValue("password").ToString();

            if (string.IsNullOrEmpty(value))
            {
                Log.Error("Could not cast password to string or it password doesnt exist!");
                return null;
            }

            if (!password.Equals(value))
            {
                Log.Info("User entered the wrong password.");
                return null;
            }

            User user = new User();

            try
            {
                user.FirstName = (string)item.GetValue("firstName");
                user.LastName = (string)item.GetValue("lastName");
            }
            catch (Exception ex)
            {
                Log.Error("Couldnt create user from BSON document during login.", ex);
                return null;
            }

            Log.Info("User entered the correct password.");
            return user;

        }

        public async Task<User> LoginFacebook(string userId)
        {
            var items = await _dbService.FindItems(Collections.Users, "facebookID", userId);

            if (items.Count > 1)
                Log.Error("Found several ambigous results when looking for facebook users!");

            var item = items.FirstOrDefault();

            if (item == null)
            {
                Log.Info("Found no facebook users to log in");

                return null;
            }

            User user = new User();

            try
            {
                user.FirstName = (string)item.GetValue("firstName");
                user.LastName = (string)item.GetValue("lastName");
                user.FacebookUserID = (string)item.GetValue("facebookID");
            }
            catch (Exception ex)
            {
                Log.Error("Couldnt create user from BSON document during login.", ex);
                return user;
            }

            Log.Info("Facebook user found.");
            return user;
        }
    }
}
