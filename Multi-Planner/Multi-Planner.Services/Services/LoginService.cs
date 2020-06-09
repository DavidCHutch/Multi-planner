using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Multi_Planner.DataModel;
using Multi_Planner.Services.Interfaces;

namespace Multi_Planner.Services.Services
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {

        }

        public Task<ServiceResponse<bool>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
