using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.reposiories
{
    public interface IDbContextProvider 
    {
        DbContext GetDbContext();
    }


  

}
