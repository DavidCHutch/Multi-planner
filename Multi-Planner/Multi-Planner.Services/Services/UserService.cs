using Multi_Planner.DataModel;
using Multi_Planner.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Net.Http.Headers;
using MongoDB.Bson;

namespace Multi_Planner.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ILog Log;
        private readonly IMongoService _dbService;
        

        public UserService(ILog log, IMongoService dbService)
        {
            Log = log;
            _dbService = dbService;
        }

        public async Task<User> CreateUser(string firstName, string lastName, string email, string password)
        {

            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.ID = Guid.NewGuid();
            user.DateCreated = DateTime.Now;
            user.LastLogin = DateTime.Now;

            //TODO Hash and protect this.
            user.Password = password;

            var document = new BsonDocument
            {
                { "ID", user.ID.ToString() },
                { "FirstName", user.FirstName },
                { "LastName", user.LastName },
                { "Email", user.Email },
                { "LastLogin", user.LastLogin},
                { "DateCreated", user.DateCreated},
                { "FacebookUserID", "" },
                { "FacebookAcessToken", "" }
            };

            bool succes = await _dbService.InsertItem(Collections.Users, document);

            if (succes)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

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
