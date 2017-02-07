using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Randy.FrameworkCore.ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Randy.FrameworkCore
{
    public class FrameworkStartup
    {


        public static void InitFramework()
        {
            InitFramework((container) => {});
        }

        public static void InitFramework(Action<IocManager> action)
        {
            //IocManager.Instance.RegisterAssemblyByConvention("");
            IocManager.Instance.RegisterAssemblyByConvention(typeof(IocManager).GetTypeInfo().Assembly);
            action(IocManager.Instance);
        }

     
        /// <summary>
        /// for replace the asp.net core default ioc contaniner
        /// </summary>
        /// <param name="populateService">defaul service</param>
        /// <returns></returns>
        public static IServiceProvider GetAutofacProvider(IServiceCollection populateService)
        {
            InitFramework();
            IocManager.Instance.GetBuilder().Populate(populateService);
            return new AutofacServiceProvider(IocManager.Instance.GetContanier());
        }


        /// <summary>
        /// for replace the asp.net core default ioc contaniner
        /// </summary>
        /// <param name="populateService">defaul service</param>
        /// <param name="assemblyName">assemblyName array</param>
        /// <returns></returns>
        public static IServiceProvider GetAutofacProvider(IServiceCollection populateService, string[] assemblyName)
        {
            if (assemblyName != null)
            {
                foreach (var item in assemblyName)
                {
                    IocManager.Instance.RegisterAssemblyByConvention(item);

                }
            }

            return GetAutofacProvider(populateService);
        }

    }
}
