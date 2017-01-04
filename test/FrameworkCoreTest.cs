using Randy.FrameworkCore;
using Randy.FrameworkCore.ioc;
using Randy.FrameworkCore.repository;
using System;
using System.Reflection;
using Xunit;

namespace Tests
{
    public class FrameworkCoreTest
    {

        public FrameworkCoreTest()
        {
            //var assembly = this.GetType().GetTypeInfo().Assembly;
            IocManager.Instance.RegisterAssemblyByConvention("Randy.FrameworkCore");
          
        }

        [Fact]
        public void ResolveTest()
        {

            var ioc = IocManager.Instance;

            var ff = ioc.Resolve<IocManager>();
       
            var result = ioc.IsRegistered<IocManager>();
            result = ioc.IsRegistered<IIocManager>();
            result = ioc.IsRegistered<ITestRepository>();
            result = ioc.IsRegistered<TestRepository>();

            var test = ioc.Resolve<ITestRepository>();
            test.GetTest();

            Assert.NotNull(ff);
        }
    }
}
