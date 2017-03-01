using Randy.FrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Application
{
    public class UserService : ApplicationServices, IUserService
    {
        public void Test()
        {
            Console.WriteLine("Test");
        }
    }

}
