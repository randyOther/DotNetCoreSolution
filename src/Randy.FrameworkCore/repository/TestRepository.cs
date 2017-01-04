using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.repository
{
    public class TestRepository : ITestRepository, IDependentInjection
    {

        public NoneRepository NoneRepository { get; set; }

        public void GetTest()
        {
            NoneRepository.Test();
        }

    }
}
