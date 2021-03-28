using Logger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.DAL
{
    internal class LoggerContext : DbContext
    {
        private readonly string connectionString;
        internal DbSet<Log> Logs { get; set; }

        public LoggerContext()
        {
            connectionString = "C://Logs//Logger.db";
        }
        public LoggerContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={connectionString}");
        }
    }
}
