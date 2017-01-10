using Randy.FrameworkCore;
using Randy.FrameworkCore.aspects;
using Randy.FrameworkCore.ioc;
using Randy.FrameworkCore.log4net;
using System.Reflection;
using test.TestModels;
using Xunit;

namespace Tests
{
    public class FrameworkCoreTest
    {

        public FrameworkCoreTest()
        {
            var assembly = typeof(IocManager).GetTypeInfo().Assembly;
            IocManager.Instance.RegisterAssemblyByConvention(typeof(IocManager).GetTypeInfo().Assembly);
            IocManager.Instance.RegisterAssemblyByConvention(this.GetType().GetTypeInfo().Assembly);
        }

        [Fact]
        public void ResolveTest()
        {

            var ioc = IocManager.Instance;

            var manager = ioc.Resolve<IocManager>();
       
            var result = ioc.IsRegistered<IocManager>();

            //return false
            result = ioc.IsRegistered<LogWrap>();
            result = ioc.IsRegistered<Repository>();
            Assert.False(result);

            //return true
            result = ioc.IsRegistered<ILogWrap>();
            result = ioc.IsRegistered<IRepository>();

            Assert.True(result);
            Assert.NotNull(manager);
        }


        [Fact]
        public void LogTest()
        {
            var log = IocManager.Instance.Resolve<ILogWrap>();

            for (int i = 0; i < 10; i++) {
                log.Write(@"远处的山，是一座芳草青青的山；远处的山，是一座碧绿无茵的山；远处的山，是一座枝叶繁茂的山；远处的山，是我平生所见最壮丽的山。", LogEnumType.Error);
            }
          
            //log.Write("test error",LogEnumType.Error);

        }


        [Fact]
        public void AspectTest()
        {
            var ioc = IocManager.Instance;

            var repository= ioc.Resolve<IRepository>();
            repository.Add();

            Assert.NotNull(repository);
        }
    }
}
