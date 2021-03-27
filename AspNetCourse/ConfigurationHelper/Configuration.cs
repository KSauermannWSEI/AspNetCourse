using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigurationHelper
{
    public static class Configuration
    {
        private static IConfiguration configuration;
        public static IConfiguration ConfigurationInstance
        {
            get
            {
                if (configuration is null)
                {
                    IConfigurationBuilder builder = new ConfigurationBuilder();
                    builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
                    configuration = builder.Build();
                }
                return configuration;
            }
        }
        public static string GetConnectionString(string name)
        {
            return ConfigurationInstance.GetConnectionString(name);
        }
    }
}
