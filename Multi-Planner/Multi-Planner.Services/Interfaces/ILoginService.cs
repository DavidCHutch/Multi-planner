using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Planner.Services.Interfaces
{
    public interface ILoginService : IService
    {
        Task<bool> Login(string username, string password);
    }
}
