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

        public IRepository<ls_role> RoleRepository { get; set; }
        public IRepository<ls_role_authority> RoleAuthorityRepository { get; set; }
        //public IRepository<ls_authority> AuthorityRepository { get; set; }
        //public IEventBus EventBus { get; set; }

        public ReturnPagedModel<ls_role> GetRoles(QueryPagedModel query)
        {
            ReturnPagedModel<ls_role> result = new ReturnPagedModel<ls_role>();
            int total = 0;
            result.DataList = RoleRepository.GetAllByPaged(query.pageIndex, query.pageSize, out total);
            result.Total = total;

            return result;
        }

        public ReturnModel SetRolePermission(List<int> roleIds, List<Permission> permissions)
        {
            ReturnModel result = new ReturnModel();
            if (roleIds != null && roleIds.Count > 0 && permissions != null && permissions.Count > 0)
            {

                foreach (var roleId in roleIds)
                {
                    foreach (var permssion in permissions)
                    {
                        var found = RoleAuthorityRepository.Get(g => g.RoleId == roleId && g.AuthorityId == permssion.AuthorityId);

                        if (permssion == null)
                        {
                            RoleAuthorityRepository.Insert(new ls_role_authority
                            {
                                RoleId = roleId,
                                AuthorityId = permssion.AuthorityId,
                                CreateDate = DateTime.Now
                            });
                        }
                    }

                }

            }

            return result;
        }

        public ReturnModel CreateRole(Role role)
        {
            ReturnModel result = new ReturnModel();
            var dbRole = Mapper.Map<ls_role>(role);

            var repository = RoleRepository.Get(s => (s.Code == role.Code));

            if (repository != null)
            {
                result.ReturnMessage = "角色编码已存在/role code is Duplicated";
            }
            else
            {
                dbRole.CreateByUserId = 0;
                dbRole.CreateDate = DateTime.Now;

                var lsrole = RoleRepository.Insert(dbRole);
                result.Success = lsrole.RoleId > 0;
            }

            return result;
        }

        public ReturnModel UpdateRole(Role role)
        {
            ReturnModel result = new ReturnModel();
            var dbRole = Mapper.Map<ls_role>(role);

            var repository = RoleRepository.Get(s => (s.Code == role.Code || s.RoleId == role.RoleId));

            if (repository == null)
            {
                result.ReturnMessage = "角色不存在/role is not exist";
            }
            else
            {
                repository.Name = role.Name;
                repository.ModifyByUserId = 0;
                repository.ModifyDate = DateTime.Now;
                RoleRepository.Update(repository);
                result.Success = repository.RoleId > 0;
            }

            return result;
        }

        public ReturnModel RemoveRole(Role role)
        {
            ReturnModel result = new ReturnModel();
            var dbRole = Mapper.Map<ls_role>(role);

            var repository = RoleRepository.Get(s => (s.Code == role.Code || s.RoleId == role.RoleId));

            if (repository == null)
            {
                result.ReturnMessage = "角色不存在/role is not exist";
            }
            else
            {

                RoleRepository.Delete(repository);
                result.Success = repository.RoleId > 0;
            }

            return result;
        }
    }

}
