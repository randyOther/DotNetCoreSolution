using Randy.FrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.TestModels
{
    public class TestService : ApplicationServices, ITestService
    {
        public void Test()
        {
            Console.WriteLine("Test");
        }
    }

    public interface ITestService : IDependentInjection
    {
        void Test();
    }
}
