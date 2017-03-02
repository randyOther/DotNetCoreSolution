using Randy.FrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore.eventHandler
{

    public class SendEmailHandler : IEventHandler<SendEmailEventData>
    {
        public void HandleEvent(SendEmailEventData eventData)
        {
            Console.WriteLine(eventData.FromEmail);
        }
    }
}
