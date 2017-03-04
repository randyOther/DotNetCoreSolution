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
        private ConcurrentDictionary<Type, Action<IEventData>> _handlerFactories;

        public EventBus()
        {
            _handlerFactories = new ConcurrentDictionary<Type, Action<IEventData>>();
        }


        public void Register(Type type, Action<IEventData> action)
        {
            if (_handlerFactories.ContainsKey(type))
                return;

            _handlerFactories.TryAdd(type, action);
        }


        public void Trigger(IEventData data)
        {
            Action<IEventData> action = null;

            _handlerFactories.TryGetValue(data.GetType(), out action);

            action?.Invoke(data);

        }

        ~EventBus()
        {
            _handlerFactories = null;
        }

    }


    public class EventBusInstaller
    {
        public void Install(string[] assemblyNames)
        {
            foreach (var name in assemblyNames)
            {
                var assembly = Assembly.Load(new AssemblyName(name));
                Install(assembly);
            }

        }

        public void Install(Assembly assembly)
        {

            var signletonBus = ioc.IocManager.Instance.Resolve<IEventBus>();

            if (signletonBus == null)
                return;

            var types = assembly.GetTypes();

            if (types != null && types.Count() > 0)
            {
                foreach (var type in types)
                {
                    var eventHandlerType = type.GetInterfaces().FirstOrDefault(f => f.Name == typeof(IEventHandler<>).Name);

                    if (eventHandlerType != null)
                    {
                        var t = eventHandlerType.GetGenericArguments().FirstOrDefault(s => typeof(IEventData).IsAssignableFrom(s));
                        var method = eventHandlerType.GetMethod("HandleEvent");
                        var instance = Activator.CreateInstance(type);

                        signletonBus.Register(t, (data) => { method.Invoke(instance, new[] { data }); });
                    }
                }
            }
        }
    }
}
