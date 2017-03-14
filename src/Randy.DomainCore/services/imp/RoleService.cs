using AutoMapper;
using Randy.DomainCore.DTO;
using Randy.DomainCore.enums;
using Randy.DomainCore.eventHandler;
using Randy.FrameworkCore;
using Randy.FrameworkCore.reposiories;
using Randy.Infrastructure;
using Randy.Infrastructure.entities;
using Randy.Infrastructure.interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore
{
    [LogRequest]
    public class RoleService : ApplicationServices, IRoleService
    {

        public IRepository<ls_user> UserRepository { get; set; }
        public IRepository<ls_role> RoleRepository { get; set; }
        public IRepository<ls_role_authority> RoleAuthorityRepository { get; set; }
        public IRepository<ls_authority> AuthorityRepository { get; set; }
        public IEventBus EventBus { get; set; }

        public ReturnModel<List<Role>> GetRoles()
        {
            return null;
        }

        public ReturnModel GetRolePermission(int roleId)
        {
            throw new NotImplementedException();
        }

        public ReturnModel CheckRolePermission(int roleId)
        {
            throw new NotImplementedException();
        }

        public ReturnModel CheckRolePermission(string roleCode)
        {
            throw new NotImplementedException();
        }
    }

}
