using Microsoft.EntityFrameworkCore;
using MySQL.Data.Entity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Infrastructure.dbContext
{
    public partial class MysqlDbContext : DbContext
    {
        private string _connectionString = string.Empty;

        public MysqlDbContext(string connectStr)
        {
            _connectionString = connectStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);// (@"Server=192.168.10.163;database=usersystem;uid=root;pwd=12345678");
        }


        public DbSet<Test> Test { get; set; }

    }

    public class Test
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Id { get; set; }
    }
}
