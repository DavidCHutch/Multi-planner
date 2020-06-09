using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Multi_Planner.DataModel;

namespace Multi_Planner.Services.Interfaces
{
    public interface ILoginService : IService
    {
        Task<ServiceResponse<bool>> Login(string username, string password);
    }
}
