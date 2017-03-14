using Randy.DomainCore.DTO;
using Randy.FrameworkCore;
using Randy.Infrastructure;
using Randy.Infrastructure.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore
{
    public interface IRoleService : IDependentInjection
    {
        ReturnModel GetUserRole(int userId);

    }

}
