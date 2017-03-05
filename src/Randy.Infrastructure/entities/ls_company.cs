using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Infrastructure.entities
{
    public class ls_company
    {
        [Key]
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreateByUserId { get; set; }
        public int ModifyByUserId { get; set; }
    }
}
