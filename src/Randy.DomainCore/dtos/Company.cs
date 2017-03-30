using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
    }
}
