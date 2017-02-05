using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Randy.FrameworkCore.ioc;
using Randy.FrameworkCore.log4net;

namespace Randy.FrameworkCore.aspects
{
    /// <summary>
    /// inherit this attribute for aop
    /// </summary>
    public abstract class BaseInterceptAttribute : Attribute, IInterceptor, IDependentInjection
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                OnEntry(invocation);
                invocation.Proceed();
                OnExcuted(invocation);
            }
            catch (Exception ex)
            {
                var log = IocManager.Instance.Resolve<ILogWrap>();
                log.Write("core framework catch exception",LogEnumType.Error, ex);
                Console.WriteLine(ex.Message);
            }
        }

        public abstract void OnEntry(IInvocation invocation);
        public abstract void OnExcuted(IInvocation invocation);
    }

}
