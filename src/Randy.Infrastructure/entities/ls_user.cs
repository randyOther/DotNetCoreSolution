using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Infrastructure.entities
{
    public class ls_user
    {
        public int UserId { get; set; }
        public string Pwd { get; set; }
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
    }
}
