using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using System.Reflection;
using Randy.FrameworkCore.ioc;
using Randy.FrameworkCore.reposiories;
using Microsoft.EntityFrameworkCore;

namespace Randy.FrameworkCore.aspects
{

    public class UnitofworkAttribute : BaseInterceptAttribute
    {
        private DbContext currentDbContext = null;

        public override void OnEntry(IInvocation invocation)
        {

            if (IocManager.Instance.IsRegistered<IDbContextProvider>())
            {
                var provider = IocManager.Instance.Resolve<IDbContextProvider>();
                currentDbContext = provider.GetDbContext();
            }

        }

        public override void OnExcuted(IInvocation invocation)
        {
            if (currentDbContext != null)
            {
                var strategy = currentDbContext.Model.GetChangeTrackingStrategy();

                var entities = currentDbContext.ChangeTracker.Entries();
                var isChange = entities.Any(s => s.State == EntityState.Added
                                                || s.State == EntityState.Deleted
                                                || s.State == EntityState.Modified);
                if (isChange)
                    currentDbContext.SaveChanges();
            }

        }
    }


}
