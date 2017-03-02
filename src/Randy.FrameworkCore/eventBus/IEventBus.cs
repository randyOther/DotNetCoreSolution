using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore
{
    public interface IEventBus  
    {
        void Register(Type type, Action<IEventData> action);

        void Trigger(IEventData data);
    }
}
