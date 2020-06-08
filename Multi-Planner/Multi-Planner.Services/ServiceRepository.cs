using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Multi_Planner.Services.Interfaces;
using Multi_Planner.Services.Services;

namespace Multi_Planner.Services
{
    public class ServiceRepository
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static void AddServices(IServiceCollection services) 
        {
            //services.AddScoped<[Interface], [Service]>();
            services.AddScoped<ILoginService, LoginService>();
        }
    }
}
