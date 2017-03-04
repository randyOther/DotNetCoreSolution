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

    /// <summary>
    /// TODO: 模块化 及初始化顺序规范化
    /// 执行顺序： 1、注册ioc容器  2、注册eventbus
    /// </summary>
    public class FrameworkStartup
    {
        private static string[] _assemblys { get; set; }
        
        public static void InitFramework()
        {
            InitFramework((container) => {});
        }

        public static void InitFramework(Action<IocManager> action)
        {
            //1、IOC container
            IocManager.Instance.RegisterAssemblyByConvention(typeof(IocManager).GetTypeInfo().Assembly);
            //2、Event Bus init
            //EventBusInstaller installer = new EventBusInstaller();
            //if (_assemblys != null && _assemblys.Length > 0)
            //{
            //    installer.Install(_assemblys);
            //}
            //installer.Install(typeof(IocManager).GetTypeInfo().Assembly);

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

            _assemblys = assemblyName;
            return GetAutofacProvider(populateService);
        }

    }
}
