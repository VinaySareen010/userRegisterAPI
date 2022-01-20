using Assignment2_userLogin.Utility.Services;
using Assignment2_userLogin.Utility.Services.IServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Utility
{
     public static class ServicesConfig
    {
        public static IServiceCollection AddIManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
