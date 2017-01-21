using Randy.FrameworkCore;
using System;

namespace test.TestModels
{

    //上层优先级别高
    [LogTestInterceptor]
    [AopTestInterceptor]
    public class TestAopinterfce : ITestAopinterfce, IDependentInjection
    {

        public void Add()
        {
            Console.WriteLine("add");
        }
    }

    public interface ITestAopinterfce
    {
        void Add();
    }

}
