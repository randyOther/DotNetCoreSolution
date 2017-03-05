using Randy.FrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore.eventHandler
{
    public class LoginEventData : IEventData
    {
        public int UserId { get; set; }

        public string LoginIp { get; set; }
    }

}
