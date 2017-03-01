using Randy.FrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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


    public class EventBusInstaller
    {
        public static void Install(string[] assemblyNames)
        {
            foreach (var name in assemblyNames)
            {
                var assembly = Assembly.Load(new AssemblyName(name));
                Install(assembly);
            }
      
        }

        public static void Install(Assembly assembly)
        {
            //todo: 注册type 处理对应事件 
            //var types = assembly.GetTypes();
            //if (types != null && types.Count() > 0)
            //{
            //    foreach (var type in types)
            //    {
            //        if (typeof(IDependentInjection).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
            //        {
                        
            //        }
            //    }
            //}
        }
    }
}
