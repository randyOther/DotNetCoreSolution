using Microsoft.EntityFrameworkCore;
using Randy.FrameworkCore;
using Randy.FrameworkCore.aspects;
using Randy.FrameworkCore.ioc;
using Randy.FrameworkCore.log4net;
using Randy.FrameworkCore.reposiories;
using System;
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
            result = ioc.IsRegistered<TestAopinterfce>();
            Assert.False(result);

            //return true
            result = ioc.IsRegistered<ILogWrap>();
            result = ioc.IsRegistered<ITestAopinterfce>();

            Assert.True(result);
            Assert.NotNull(manager);
        }


        [Fact]
        public void LogTest()
        {
            var log = IocManager.Instance.Resolve<ILogWrap>();

            for (int i = 0; i < 10; i++)
            {
                log.Write(@"远处的山，是一座芳草青青的山；远处的山，是一座碧绿无茵的山；远处的山，是一座枝叶繁茂的山；远处的山，是我平生所见最壮丽的山。", LogEnumType.Error);
            }

            //log.Write("test error",LogEnumType.Error);

        }


        [Fact]
        public void AspectTest()
        {
            var ioc = IocManager.Instance;

            var repository = ioc.Resolve<ITestAopinterfce>();
            repository.Add();

            Assert.NotNull(repository);
        }


        [Fact]
        public void DbContextTest()
        {
            var f = IocManager.Instance.IsRegistered<IRepository<Randy.FrameworkCore.reposiories.test>>();

            var repositories = IocManager.Instance.Resolve<IRepository<Randy.FrameworkCore.reposiories.test>>();

            var db = IocManager.Instance.Resolve<IDbContextProvider>();
            var dbcon = db.GetDbContext();  //idbcontext don't imp class

            var db1 = IocManager.Instance.Resolve<IDbContextProvider>();
            var dbcon1 = db1.GetDbContext();

            Assert.Equal(dbcon, dbcon1);

            var all = repositories.GetAllList();
       
            var all1 = repositories.GetAllByPaged(1,1);
            var all2 = repositories.GetAllByPaged(2, 1);

            var test = repositories.Insert(new Randy.FrameworkCore.reposiories.test { Name = "Jenny", Phone = "110" });
            //repositories.Commit();


            Assert.NotNull(test);
            Assert.True(test.Id > 0);
            //var repositories = IocManager.Instance.Resolve<IRepository<A>>();

        }

        [Fact]
        public void UniofWorkServicesTest()
        {
            var ioc = IocManager.Instance;

            var testService = ioc.Resolve<ITestService>();

            testService.Test();

        }

        [Fact]
        public void EventBusTest()
        {
            var ioc = IocManager.Instance;
   
        }



        [Fact]
        public void ConfigrationTest()
        {
            var value= ConfigurationManager.GetConfigValue("connectionStrings");
            var value1 = ConfigurationManager.GetConfigSection("system");
            var ff= value1["a"];

            Assert.NotNull(value);
            Assert.NotEmpty(value);

        }


    }

         

}
