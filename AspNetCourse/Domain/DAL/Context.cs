using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL
{
    public class Context : DbContext
    {
        public DbSet<AvailableService> AvailableServices { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public Context()
        {
            sqlServer = ConfigurationHelper.Configuration.GetConnectionString("SQLServer");
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        private readonly string sqlServer;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (sqlServer != null)
            {
                optionsBuilder.UseSqlServer(sqlServer);
            }
        }
    }
}
