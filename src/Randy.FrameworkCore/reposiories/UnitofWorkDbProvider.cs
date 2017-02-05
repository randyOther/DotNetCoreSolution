using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.reposiories
{
    public class UnitofWorkDbProvider : IDbContextProvider//, IDependentInjection
    {
        private DbContext _dbcontext;
        public DbContext GetDbContext()
        {
            if (_dbcontext == null)
                _dbcontext = new MysqlDbContext();
            
            return _dbcontext;
        }

    }

}
