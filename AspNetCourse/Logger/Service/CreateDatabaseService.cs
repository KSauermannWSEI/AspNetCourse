using Logger.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Service
{
    internal static class CreateDatabaseService
    {
        internal static LoggerContext CreateDatabase(string connectionString)
        {
            if (connectionString is null)
            {
                throw new ArgumentNullException("Connectonstring can not be null");
            }
            var dbContext = new LoggerContext(connectionString);
            if (!File.Exists(connectionString))
            {
                var dir = new FileInfo(connectionString).Directory.FullName;
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.Create(connectionString).Close();

                dbContext.Database.Migrate();
                return dbContext;
            }
            return dbContext;
        }
    }
}
