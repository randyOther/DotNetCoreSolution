using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Randy.FrameworkCore.aspects
{
    /// <summary>
    /// inherit this attribute for aop
    /// </summary>
    public abstract class BaseInterceptAttribute : Attribute, IInterceptor, IDependentInjection
    {
        public void Intercept(IInvocation invocation)
        {
            OnEntry(invocation);
            invocation.Proceed();
            OnExcuted(invocation);
        }

        public abstract void OnEntry(IInvocation invocation);
        public abstract void OnExcuted(IInvocation invocation);
    }

}
