using Randy.FrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore.eventHandler
{
    public class SendEmailEventData : IEventData
    {
        public string Message { get; set; }

        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
    }

}
