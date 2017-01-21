using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Randy.FrameworkCore.aspects
{

    public class UnitofworkAttribute : BaseInterceptAttribute
    {

        public override void OnEntry(IInvocation invocation)
        {
            Console.WriteLine("UnitofworkAttribute before");
        }

        public override void OnExcuted(IInvocation invocation)
        {
            Console.WriteLine("UnitofworkAttribute after");
        }
    }


}
