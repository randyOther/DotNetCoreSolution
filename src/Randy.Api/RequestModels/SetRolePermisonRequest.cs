using Randy.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Api.RequestModels
{
    public class SetRolePermisonRequest
    {
        public List<Permission> permissions { get; set; }
        public List<int> roleIds { get; set; } 
    }


    public class SetUserRoleRequest
    {
        public List<Role> roles { get; set; }
        public List<int> userIds { get; set; }
    }


    
}
