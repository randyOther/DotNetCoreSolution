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
}
