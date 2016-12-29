using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.ioc
{
    public enum DependencyLifeStyleEnum
    {
        Transient,
        Singleton,
        //PerLifetimeScope,
        //PerMatchingLifetimeScope
    }
}
