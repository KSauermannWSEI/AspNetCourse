using Domain.Models;
using HairdressingApi.Controllers;
using Logger.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingApi.Middleware
{
    public static class RegisterLoggerServices
    {
        public static IServiceCollection AddLoggers(this IServiceCollection services)
        {
            services.AddLogger<AvailableServicesController>();
            services.AddLogger<PeopleController>();
            services.AddLogger<PersonTypesController>();
            services.AddLogger<PricesController>();
            services.AddLogger<ServiceTypesController>();
            services.AddLogger<VisitsController>();
            return services;
        }
    }
}
