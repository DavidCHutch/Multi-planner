using Multi_Planner.DataModel;
using Multi_Planner.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Planner.Services.Services
{
    // TODO This is an old version, check if its needed then remove
    public class FacebookService : IFacebookService
    {
        public async Task<bool> AuthenticateToken(string accessToken, string userId = "")
        {
            return true;
        }
    }
}
