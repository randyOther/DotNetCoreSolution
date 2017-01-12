using Autofac;
using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Features.Scanning;
using Castle.DynamicProxy;
using Castle.DynamicProxy.Internal;

namespace Randy.FrameworkCore.ioc
{
    public static partial class RegistrationExtensions
    {
        public static IRegistrationBuilder<TImplementer, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType<TImplementer>(this ContainerBuilder builder, DependencyLifeStyleEnum lifeType)
        {
            var result = Autofac.RegistrationExtensions.RegisterType<TImplementer>(builder).PropertiesAutowired();
            switch (lifeType)
            {
                case DependencyLifeStyleEnum.Transient:
                    return result.InstancePerDependency();

                case DependencyLifeStyleEnum.Singleton:
                    return result.SingleInstance();

                default:
                    return result.InstancePerDependency();
            }
        }







    }
}
