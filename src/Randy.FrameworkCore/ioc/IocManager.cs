using Autofac;
using Castle.DynamicProxy;
using Randy.FrameworkCore.aspects;
using Randy.FrameworkCore.reposiories;
using System;
using System.Linq;
using System.Reflection;

namespace Randy.FrameworkCore.ioc
{
    public sealed class IocManager
    {

        public static IocManager Instance { get; private set; }

        private ContainerBuilder _builder;
        private IContainer _container;

        static IocManager()
        {
            Instance = new ioc.IocManager();
        }

        public IocManager() { Init(); }

        private void Init()
        {
            _builder = new ContainerBuilder();
            //Register self!
            _builder.RegisterType<IocManager>(DependencyLifeStyleEnum.Singleton).PropertiesAutowired(); 
            _builder.RegisterType<EventBus>(DependencyLifeStyleEnum.Singleton).PropertiesAutowired(); 
            _builder.RegisterType<UnitofWorkDbProvider>().As<IDbContextProvider>().InstancePerLifetimeScope().PropertiesAutowired();
        }

        /// <summary>
        /// sacn dll follow convention
        /// </summary>
        /// <param name="assembly">assembly</param>
        public void RegisterAssemblyByConvention(string assemblyName)
        {
            var assembly = Assembly.Load(new AssemblyName(assemblyName));
            RegisterAssemblyByConvention(assembly);
        }


        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            var types = assembly.GetTypes();
            if (types != null && types.Count() > 0)
            {
                foreach (var type in types)
                {
                    if (typeof(IDependentInjection).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
                    {
                        RegisterTypeWithAspect(type);
                    }
                }
            }

        }

        private void RegisterTypeWithAspect(Type type, DependencyLifeStyleEnum lifeStyle = DependencyLifeStyleEnum.Transient)
        {
            if (typeof(IDependentInjection).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
            {
                var attribute = type.GetTypeInfo().GetCustomAttributes();
                var isGenericType = type.GetTypeInfo().IsGenericType;

                if (attribute.Count() == 0)
                {
                    if (isGenericType)
                    {
                        _builder.RegisterGeneric(type, lifeStyle)
                            .As(type.GetInterfaces().FirstOrDefault(t => typeof(IDependentInjection) != t)).PropertiesAutowired();
                    }
                    else
                    {
                        _builder.RegisterType(type, lifeStyle).AsImplementedInterfaces().PropertiesAutowired();
                    }
                }
                else
                {

                    var interceptTypes = attribute.Where(s => typeof(IInterceptor).IsAssignableFrom(s.GetType()) 
                        && typeof(Attribute).IsAssignableFrom(s.GetType())).Select(s => s.GetType());

                    //register attribute
                    if (interceptTypes != null && interceptTypes.Count() > 0)
                    {
                        _builder.RegisterTypes(interceptTypes.ToArray());

                        //register type if contains aop attribute
                        if (isGenericType)
                        {
                            _builder.RegisterGeneric(type, lifeStyle)
                                .As(type.GetInterfaces().FirstOrDefault(t => typeof(IDependentInjection) != t))
                                .EnableInterfaceInterceptors().InterceptedBy(interceptTypes.ToArray()).PropertiesAutowired();
                        }
                        else
                        {
                            _builder.RegisterType(type, lifeStyle).AsImplementedInterfaces().EnableInterfaceInterceptors()
                                    .InterceptedBy(interceptTypes.ToArray()).PropertiesAutowired();
                        }

                    }
                }
            }

        }


        /// <summary>
        /// cann't be working after container builded
        /// </summary>
        /// <param name="type"></param>
        /// <param name="lifeStyle"></param>
        public void Register<T>(DependencyLifeStyleEnum lifeStyle = DependencyLifeStyleEnum.Transient)
        {
            RegisterTypeWithAspect(typeof(T), lifeStyle);
        }


        public bool IsRegistered(Type type)
        {
            if (_container == null)
                _container = _builder.Build();

            return _container.IsRegistered(type);
        }

        public bool IsRegistered<T>()
        {
            if (_container == null)
                _container = _builder.Build();

            return _container.IsRegistered(typeof(T));
        }

        public object Resolve(Type t)
        {
            if (_container == null)
                _container = _builder.Build();

            return _container.Resolve(t);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public IContainer GetContanier()
        {
            if (_container == null)
                _container = _builder.Build();

            return _container;
        }

        public ContainerBuilder GetBuilder()
        {
            return _builder;
        }

    }
}
