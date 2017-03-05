using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySQL.Data.Entity.Extensions;
using Randy.FrameworkCore;
using Randy.FrameworkCore.reposiories;
using Randy.Infrastructure.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Infrastructure
{
    public partial class BaseDbContext : DbContext, IDbContext
    {
        private string _connectionString;


        public BaseDbContext()
        {
            _connectionString = ConfigurationManager.GetConfigValue("connectionStrings");
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySQL(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ls_authority>().HasKey(d => d.AuthorityId);
            base.OnModelCreating(modelBuilder);
        }

        public DbContext GetCurrentDbcontext()
        {
            return this;
        }

        public DbSet<test> Test { get; set; }
        public DbSet<ls_authority> ls_authority { get; set; }
        public DbSet<ls_company> ls_company { get; set; }
        public DbSet<ls_department> ls_department { get; set; }
        public DbSet<ls_role> ls_role { get; set; }
        public DbSet<ls_role_authority> ls_role_authority { get; set; }
        public DbSet<ls_user> ls_user { get; set; }
        public DbSet<ls_user_info> ls_user_info { get; set; }
        public DbSet<ls_user_role> ls_user_role { get; set; }
    

    }


}
