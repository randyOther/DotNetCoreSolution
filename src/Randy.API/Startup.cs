using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Randy.FrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using Randy.Api.MiddlerWares;

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


            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "Version 1.0",
                    Title = "Core API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    //Contact = new Contact { Name = "Shayne Boyer", Email = "", Url = "http://twitter.com/spboyer" },
                    //License = new License { Name = "Use under LICX", Url = "http://url.com" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(Path.Combine(basePath, "Randy.Api.xml"));
                c.IncludeXmlComments(xmlPath);
            });


            return FrameworkStartup.GetAutofacProvider(services);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //use template swagger didnot work
            app.UseMvc();
            //custom 
            app.TestMiddlerWare();
            app.UseSwagger();
            app.UseSwaggerUi(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1.0");
            });
        }
    }
}
