﻿using Randy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role
    {
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string Code { get; set; }

        public int DepartmentId { get; set; }

        public List<Permission> Permissions { get; set; }

        public bool CheckRolePerssion(int authorityId)
        {
            if (Permissions == null)
                throw new BusinessException("Role: Permissions decline!");

            if (Permissions != null && Permissions.Any(s => s.AuthorityId == authorityId))
                return true;

            return false;
        }

    }




}
