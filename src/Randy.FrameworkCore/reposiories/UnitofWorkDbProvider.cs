using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.reposiories
{
    public class UnitofWorkDbProvider : IDbContextProvider//, IDependentInjection
    {

        public IDbContext DbContext { get; set; }

        //private DbContext _dbcontext;
        public DbContext GetDbContext()
        {
            return DbContext.GetCurrentDbcontext();
        }

    }

}
