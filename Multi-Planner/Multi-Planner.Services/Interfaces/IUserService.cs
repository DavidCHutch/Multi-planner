using Multi_Planner.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Planner.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<ServiceResponse<User>> GetUserByFacebookId(string userId);
        Task<ServiceResponse<User>> CreateFacebookUser(string userId, string accessToken);

    }
}
