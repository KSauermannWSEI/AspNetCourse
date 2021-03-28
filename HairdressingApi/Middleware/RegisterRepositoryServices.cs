using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingApi.Middleware
{
    public static class RegisterRepositoryServices
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        { 
            services.AddTransient<IRepository<AvailableService>, Repository<AvailableService>>(); 
            services.AddTransient<IRepository<Person>, Repository<Person>>(); 
            services.AddTransient<IRepository<PersonType>, Repository<PersonType>>();        
            services.AddTransient<IRepository<Price>, Repository<Price>>(); //Dependency Injection  
            services.AddTransient<IRepository<ServiceType>, Repository<ServiceType>>(); 
            services.AddTransient<IRepository<Visit>, Repository<Visit>>(); 

            //services.AddScoped<IPricesRepository, PricesRepository>();
            //services.AddSingleton<IPricesRepository, PricesRepository>();
            return services;
        }
    }
}
