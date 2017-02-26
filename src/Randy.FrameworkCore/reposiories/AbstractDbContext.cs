using Microsoft.EntityFrameworkCore;
using MySQL.Data.Entity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.reposiories
{

    /// <summary>
    /// for test mysql dbcontext
    /// </summary>
    //public partial class MysqlDbContext : DbContext, IDbContext
    //{
    //    private string _connectionString = ConfigurationManager.GetConfigValue("connectionStrings");

        
    //    public MysqlDbContext() { }

    //    public virtual string GetConnectionString(string str)
    //    {
    //        return _connectionString;
    //    }
             

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
         
    //        optionsBuilder.UseMySQL(_connectionString);      
    //    }

    //    public DbContext GetCurrentDbcontext()
    //    {
    //        return this;
    //    }

    //    public DbSet<test> Test { get; set; }

    //}


    public interface IDbContext : IDependentInjection
    {
        //string GetConnectionString(string str);
        DbContext GetCurrentDbcontext();
    }


    //注意linux下区分大小写
    public class test
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Id { get; set; }
    }
}
