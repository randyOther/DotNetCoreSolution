using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.ioc
{
    public class IocManager : IIocManager
    {

        public static IocManager Instance { get; private set; }

        private ContainerBuilder _builder;
        private IContainer _container;

        static IocManager()
        {
            Instance = new ioc.IocManager();
        }

        public IocManager()
        {
            _builder = new ContainerBuilder();
            //Register self!
            _builder.RegisterType<IocManager>(DependencyLifeStyleEnum.Singleton);
            _builder.RegisterType<IocManager>(DependencyLifeStyleEnum.Singleton).As<IIocManager>();

            RegisterAssemblyByConvention(Assembly.GetEntryAssembly());

            _container = _builder.Build();
        }

        /// <summary>
        /// sacn dll follow convention
        /// </summary>
        /// <param name="assembly">such as from Assembly.GetExecutingAssembly()</param>
        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            _builder.RegisterAssemblyTypes(assembly); //.Where(s => s.GetInterfaces().Contains(typeof(IDependentInjection)));
            //_container = _builder.Build();
        }

        public void Register(Type type, DependencyLifeStyleEnum lifeStyle = DependencyLifeStyleEnum.Transient)
        {
            
            _builder.RegisterType<IocManager>(lifeStyle);
            //_container = _builder.Build();
            
        }

        public void Register<TType, TImpl>(DependencyLifeStyleEnum lifeStyle = DependencyLifeStyleEnum.Transient)
             where TType : class
            where TImpl : class, TType
        {
            _builder.RegisterType<TImpl>(lifeStyle).As<TType>();
            //_container = _builder.Build();
        }

        public bool IsRegistered(Type type)
        {
            return _container.IsRegistered(type);
        }

        public bool IsRegistered<T>()
        {
            return _container.IsRegistered(typeof(T));
        }

        public object Resolve(Type t)
        {
            return _container.Resolve(t);
        }

        public T Resolve<T>()
        {
            return (T)_container.Resolve(typeof(T));
        }

    }
}
