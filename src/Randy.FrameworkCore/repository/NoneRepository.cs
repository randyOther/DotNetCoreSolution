using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.repository
{
    public class NoneRepository : IDependentInjection
    {
        public void Test()
        {
            Console.WriteLine("Hello  Test");
        }

    }
}
