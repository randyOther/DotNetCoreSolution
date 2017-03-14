using Randy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore.DTO
{
    public class User
    {

        public int UserId { get; set; }
        public string Email { get; set; }

        public DateTime LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreateByUserId { get; set; }
        public int ModifyByUserId { get; set; }
        
        public UserDetail Detail { get; set; }
    }

    public class UserDetail
    {
        public UserInfo Info { get; set; }
        public List<Role> Roles { get; set; }

        public bool IsRole(int roleId)
        {
            if (Roles == null)
                throw new BusinessException("UserDetail: Roles is null");

            if (Roles != null && Roles.Any(s => s.RoleId == roleId))
                return true;

            return false;
        }

        public bool IsRole(string roleName)
        {
            if (Roles == null)
                throw new BusinessException("UserDetail: Roles is null");

            if (Roles != null && Roles.Any(s => s.Name == roleName))
                return true;

            return false;
        }
    }
    

    public class SignUpInput
    {
        /// <summary>
        /// email or phone
        /// </summary>
        public string UserName { get; set; }
        public string Password{get;set;}
        
        public string CompanyName { get; set; }
    }
}
