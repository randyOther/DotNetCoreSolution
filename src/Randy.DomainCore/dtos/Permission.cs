using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore
{
    /// <summary>
    /// 权限
    /// </summary>
    public class Permission
    {
        public string Name { get; set; }
        public int AuthorityId { get; set; }

    }
}
