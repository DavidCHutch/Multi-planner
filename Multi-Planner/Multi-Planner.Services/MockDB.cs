using Multi_Planner.DataModel;
using Multi_Planner.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multi_Planner.Services
{
    public class MockDB
    {
        private static readonly MockDB _MockDB = new MockDB();

        public static MockDB GetInstance() => _MockDB;

        private Dictionary<Guid, User> UserStorage;

        public MockDB()
        {
            UserStorage = new Dictionary<Guid, User>();
        }

        public User SaveUser(User user)
        {
            user.ID = Guid.NewGuid();
            UserStorage.Add(user.ID, user);

            return user;
        }

        public User RetrieveUser(Guid id)
        {
            var users = UserStorage.Values.Where(u => u.ID == id);

            return users.FirstOrDefault();
        }

        public (User,int) RetrieveUserByFacebookId(string userid)
        {
            var users = UserStorage.Values.Where(u => u.FacebookUserID.Equals(userid));

            return (users.FirstOrDefault(), users.Count());
        }

        public User UpdateUser(User user)
        {
            User userToBeUpdated;
            bool success = UserStorage.TryGetValue(user.ID, out userToBeUpdated);

            if (success)
            {
                userToBeUpdated = user;
                return userToBeUpdated;
            }
            else
            {
                return null;
            }
        }

    }
}
