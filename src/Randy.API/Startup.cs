using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Randy.FrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.Swagger.Model;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Randy.FrameworkCore.ioc;

namespace Randy.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();


            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "Version 1.0",
                    Title = "Demo API",
                    Description = "RESTful for ASP.NET Core",
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                options.IncludeXmlComments(basePath + "\\Randy.Api.xml");
            });


            ////inject controller  ? 
            //var manager = new ApplicationPartManager();
            //manager.ApplicationParts.Add(new AssemblyPart(this.GetType().GetTypeInfo().Assembly));
            //manager.FeatureProviders.Add(new ControllerFeatureProvider());
            //IocManager.Instance.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            //IocManager.Instance.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();

            return FrameworkStartup.GetAutofacProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //use template swagger didnot work
            app.UseMvc();
        
            app.UseSwagger();
            app.UseSwaggerUi();
        }
}
}
