using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore.DTO
{
    public class UserInfo
    {
        public int UserInfoId { get; set; }
        public int UserId { get; set; }
        public string RealName { get; set; }
        public string NickName { get; set; }
        public string IdCardType { get; set; }
        public string IdCardNo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }

        public string Remark { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ExtendInfo { get; set; }

        public Company Company { get; set; }

        public Role Role { get; set; }

    }

}
