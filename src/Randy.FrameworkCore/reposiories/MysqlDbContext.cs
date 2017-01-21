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
    public partial class MysqlDbContext : DbContext
    {
        private string _connectionString = string.Empty;


        public MysqlDbContext() { }

        public MysqlDbContext(string connectStr)
        {
            _connectionString = connectStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=192.168.0.102;database=usersystem;uid=root;pwd=12345678");// 
        }


        public DbSet<test> Test { get; set; }

    }


    public class UnitofWorkDbProvider : IDbContextProvider,IDependentInjection
    {
        private DbContext _dbcontext;
        public DbContext GetDbContext()
        {
            if (_dbcontext == null)
                _dbcontext = new MysqlDbContext();

            return _dbcontext;
        }

    }

    //注意linux下区分大小写
    public class test
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Id { get; set; }
    }
}
