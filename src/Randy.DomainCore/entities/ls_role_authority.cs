using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Infrastructure.entities
{
    public class ls_role_authority
    {
        public int RoleAuthorityId { get; set; }
        public int RoleId { get; set; }
        public int AuthorityId { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreateByUserId { get; set; }
        public int ModifyByUserId { get; set; }
    }
}
