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
    public class PermissionService : ApplicationServices, IPermissionService
    {

        public IRepository<ls_authority> PermissionRepository { get; set; }

        //public IEventBus EventBus { get; set; }

        public ReturnPagedModel<ls_authority> GetPermissions(QueryPagedModel query)
        {
            ReturnPagedModel<ls_authority> result = new ReturnPagedModel<ls_authority>();
            int total = 0;
            result.DataList = PermissionRepository.GetAllByPaged(query.pageIndex, query.pageSize, out total);
            result.Total = total;

            return result;
        }


        public ReturnModel CreatePermission(Permission permission)
        {
            ReturnModel result = new ReturnModel();

            var p = PermissionRepository.Insert(new ls_authority
            {
                Name = permission.Name,
                CreateDate = DateTime.Now,
                Status = "ACTIVE",
                PorityLevel = "NORMAL"
            });
            result.Success = p.AuthorityId > 0;

            return result;
        }

        public ReturnModel UpdatePermission(Permission permission)
        {
            ReturnModel result = new ReturnModel();
            
            var repository = PermissionRepository.Get(s => (s.AuthorityId == permission.AuthorityId));

            if (repository == null)
            {
                result.ReturnMessage = "权限不存在/Permission is not exist";
            }
            else
            {
                repository.Status = permission.Status;
                repository.Permission = permission.PermissionName;
                repository.Name = permission.Name;
                repository.ModifyByUserId = 0;
                repository.ModifyDate = DateTime.Now;
                PermissionRepository.Update(repository);
                result.Success = true;
            }

            return result;
        }

        public ReturnModel RemovePermission(Permission permission)
        {
            ReturnModel result = new ReturnModel();

            var repository = PermissionRepository.Get(s => (s.AuthorityId == permission.AuthorityId));

            if (repository == null)
            {
                result.ReturnMessage = "权限不存在/permission is not exist";
            }
            else
            {

                PermissionRepository.Delete(repository);
                result.Success = true;
            }

            return result;
        }
    }

}
