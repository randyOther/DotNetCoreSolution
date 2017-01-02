using Randy.FrameworkCore;
using Randy.FrameworkCore.ioc;
using Randy.FrameworkCore.repository;
using System;
using Xunit;

namespace Tests
{
    public class FrameworkCoreTest
    {
        [Fact]
        public void ResolveTest() 
        {

            var ioc = IocManager.Instance;


            ioc.RegisterAssemblyByConvention("Randy.FrameworkCore");


            var ff= ioc.Resolve<IocManager>();

            var result= ioc.IsRegistered<IocManager>();
            result = ioc.IsRegistered<IIocManager>();
            result = ioc.IsRegistered<ITestRepository>();
            result = ioc.IsRegistered<TestRepository>();

            Assert.NotNull(ff);
        }
    }
}
