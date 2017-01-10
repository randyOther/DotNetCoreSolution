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
 
    //上层优先级别高
    [LogTestInterceptor]
    [AopTestInterceptor]
    public class Repository : IRepository, IDependentInjection
    {

        public void Add()
        {
            Console.WriteLine("add");
        }
    }

    public interface IRepository 
    {
        void Add();
    }



}
