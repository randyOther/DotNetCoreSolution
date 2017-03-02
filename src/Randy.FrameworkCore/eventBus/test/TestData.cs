using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.eventBus.test
{
    public class TestData1 :IEventData
    {
        public string name = "randy test";
    }

    public class LogHandler : IEventHandler<TestData1>
    {
        public void HandleEvent(TestData1 eventData)
        {
            Console.WriteLine(eventData.name);
        }
    }

}
