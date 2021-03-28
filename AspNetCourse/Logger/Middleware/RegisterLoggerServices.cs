using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Middleware
{
    public static class RegisterLoggerServices
    {
        public static IServiceCollection AddLogger<T>(this IServiceCollection services) //, IConfiguration configuration)
        {
            //var logger = new AppLogger<T>(configuration);
            //services.AddSingleton<ILogger>(logger);
            services.AddSingleton<ILogger<T>, AppLogger<T>>();
            return services;
        }
    }
}
