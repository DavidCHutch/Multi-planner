using Multi_Planner.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Planner.Services.Interfaces
{
    public interface IFacebookService : IService
    {
        Task<ServiceResponse<Uri>> GetLoginUrl(Uri redirectUri);
        Task<ServiceResponse<bool>> GetAccessToken(string code, Uri redirectUri);
        Task<ServiceResponse<bool>> SaveToken(FacebookAccessToken token);
    }
}
