using Autofac;
using Castle.DynamicProxy;
using Randy.FrameworkCore;
using Randy.FrameworkCore.aspects;
using Randy.FrameworkCore.ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace test.TestModels
{

    /// <summary>
    /// Test aop attribute
    /// </summary>
    public class AopTestInterceptorAttribute : BaseInterceptAttribute
    {

        public override void OnEntry(IInvocation invocation)
        {
            Console.WriteLine("AopTestInterceptorAttribute before");
        }

        public override void OnExcuted(IInvocation invocation)
        {
            Console.WriteLine("AopTestInterceptorAttribute after");
        }
    }

    public class LogTestInterceptorAttribute : BaseInterceptAttribute
    {

        public override void OnEntry(IInvocation invocation)
        {
            Console.WriteLine(" LogTestInterceptor before");
        }

        public override void OnExcuted(IInvocation invocation)
        {
            Console.WriteLine("LogTestInterceptor after");
        }

    }

}
