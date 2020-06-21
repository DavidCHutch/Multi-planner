using Multi_Planner.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Planner.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<User> CreateUser(string firstName, string lastName, string email, string password);
        Task<User> GetUserByFacebookId(string userId);
        Task<User> CreateFacebookUser(string userId, string accessToken);

    }
}
