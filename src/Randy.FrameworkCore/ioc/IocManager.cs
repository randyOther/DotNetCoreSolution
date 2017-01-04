using Autofac;
using Randy.FrameworkCore.repository;
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

        public IocManager() { Init(); }

        private void Init()
        {
            _builder = new ContainerBuilder();
            //Register self!
            _builder.RegisterType<IocManager>(DependencyLifeStyleEnum.Singleton);
            _builder.RegisterType<IocManager>(DependencyLifeStyleEnum.Singleton).As<IIocManager>();

        }

        /// <summary>
        /// sacn dll follow convention
        /// </summary>
        /// <param name="assembly">such as from Assembly.GetExecutingAssembly()</param>
        public void RegisterAssemblyByConvention(string assemblyName)
        {
            var assembly = Assembly.Load(new AssemblyName(assemblyName));
            _builder.RegisterAssemblyTypes(assembly).Where(t =>
            {
                if (t.IsAssignableTo<IDependentInjection>())
                    return true;
                else
                    return false;
            }).AsSelf().As(a =>
            {
                var clsLastName = a.FullName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                var result = a.GetInterfaces().FirstOrDefault(f =>
                                              f.FullName != typeof(IDependentInjection).FullName
                                              && f.FullName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault().Contains(clsLastName));
                return result;
            }).PropertiesAutowired();
        }
        /// <summary>
        /// cann't be working after container builded
        /// </summary>
        /// <param name="type"></param>
        /// <param name="lifeStyle"></param>
        public void Register<T>(DependencyLifeStyleEnum lifeStyle = DependencyLifeStyleEnum.Transient)
        {
            _builder.RegisterType<T>(lifeStyle);
        }

        /// <summary>
        /// cann't be working after container builded
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <typeparam name="TImpl"></typeparam>
        /// <param name="lifeStyle"></param>
        public void Register<TType, TImpl>(DependencyLifeStyleEnum lifeStyle = DependencyLifeStyleEnum.Transient)
             where TType : class
            where TImpl : class, TType
        {
            _builder.RegisterType<TImpl>(lifeStyle).AsSelf().As<TType>();
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
            if (_container == null)
                _container = _builder.Build();

            return _container.Resolve(t);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

    }
}
