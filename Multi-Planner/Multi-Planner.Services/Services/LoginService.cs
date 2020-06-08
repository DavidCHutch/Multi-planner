using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Multi_Planner.Services.Interfaces;

namespace Multi_Planner.Services.Services
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {

        }

        public async Task<bool> Login(string username, string password)
        {


            return true;
        }
    }
}
