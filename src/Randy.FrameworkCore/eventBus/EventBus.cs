using Randy.FrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore
{
    /// <summary>
    /// sigleton imp event bus
    /// </summary>
    public class EventBus : IEventBus 
    {
        //private readonly ConcurrentDictionary<Type, List<IEventHandlerFactory>> _handlerFactories;


        //public IDisposable Register<TEventData, THandler>()
        //    where TEventData : IEventData
        //    where THandler : IEventHandler<TEventData>, new()
        //{
        //    return Register(typeof(TEventData), new TransientEventHandlerFactory<THandler>());
        //}


    }
}
