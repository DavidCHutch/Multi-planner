using Multi_Planner.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Planner.Services.Interfaces
{
    public interface IFacebookService :IService
    {
        Task<bool> AuthenticateToken(string accessToken, string userId = "");
    }
}
