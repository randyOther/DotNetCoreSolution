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
        ReturnPagedModel<ls_role> GetRoles(QueryPagedModel query);

        ReturnModel SetRolePermission(List<int> roleIds, List<Permission> Permissions);

        ReturnModel CreateRole(Role role);

        ReturnModel UpdateRole(Role role);

        ReturnModel RemoveRole(Role role);

    }

}
