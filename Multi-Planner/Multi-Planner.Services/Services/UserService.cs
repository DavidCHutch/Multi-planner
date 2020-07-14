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
        // TODO This is an old version, check if its needed then remove
        private readonly ILog Log;
        private readonly IMongoService _dbService;
        

        public UserService(ILog log, IMongoService dbService)
        {
            Log = log;
            _dbService = dbService;
        }

        public async Task<User> CreateUser(string firstName, string lastName, string email, string password)
        {
            Log.Info("Creating User");
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.ID = Guid.NewGuid();
            user.DateCreated = DateTime.Now;
            user.LastLogin = DateTime.Now;
            user.FacebookUserID = "";

            //TODO Hash and protect this.
            user.Password = password;

            Log.Info("Converting data to BSON.");
            var document = new BsonDocument
            {
                { "ID", user.ID.ToString() },
                { "FirstName", user.FirstName },
                { "LastName", user.LastName },
                { "Email", user.Email },
                { "LastLogin", user.LastLogin},
                { "DateCreated", user.DateCreated},
                { "FacebookUserID", "" }
            };

            bool success = await _dbService.InsertItem(Collections.Users, document);

            if (success)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public async Task<User> CreateFacebookUser(string userId, string name)
        {
            Log.Info("Creating Facebook User");

            User user = new User();
            user.FirstName = name;
            user.LastName = "";
            user.Email = "";
            user.ID = Guid.NewGuid();
            user.DateCreated = DateTime.Now;
            user.LastLogin = DateTime.Now;
            user.Password = "";
            user.FacebookUserID = userId;

            Log.Info("Converting data to BSON.");
            var document = new BsonDocument
            {
                { "ID", user.ID.ToString() },
                { "FirstName", user.FirstName },
                { "LastName", user.LastName },
                { "Email", user.Email },
                { "LastLogin", user.LastLogin},
                { "DateCreated", user.DateCreated},
                { "FacebookUserID", user.FacebookUserID }
            };

            bool success = await _dbService.InsertItem(Collections.Users, document);

            if (success)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
