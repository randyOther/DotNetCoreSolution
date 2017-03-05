using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Infrastructure.entities
{
    /// <summary>
    /// ef约定
    /// 1.0 每张表必须含有key标识
    /// </summary>
    public class ls_user
    {
        [Key]
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
