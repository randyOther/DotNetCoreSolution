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
using System.Reflection;
using System.Runtime.Loader;
using AutoMapper;
using Randy.Infrastructure;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

            //Json web token
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .AddRequirements(new ValidJtiRequirement())
                    .Build());
            });

            // 注册验证要求的处理器，可通过这种方式对同一种要求添加多种验证
            services.AddSingleton<IAuthorizationHandler, ValidJtiHandler>();

            // Add framework services.
            services.AddMvc();

            //swagger ui
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "1.1 alpha",  //beta
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

            
            return FrameworkStartup.GetAutofacProvider(services,
                                                       new string[] { this.GetType().GetTypeInfo().Assembly.FullName,
                                                            typeof(DomainCore.DomainCoreMain).GetTypeInfo().Assembly.FullName ,
                                                            typeof(Infrastructure.BaseDbContext).GetTypeInfo().Assembly.FullName  });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //automapping
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainCore.dtos.DtoMapperProfile>();
            });

            //set configuration
            Infrastructure.ConfigurationManager.SetConfig(Configuration);

            //json web token
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = JsonWebTokenSource._tokenOptions.Key,
                    ValidAudience = JsonWebTokenSource._tokenOptions.Audience, // 设置接收者必须一致
                    ValidIssuer = JsonWebTokenSource._tokenOptions.Issuer, // 设置签发者必须一致
                    ValidateLifetime = true,
                }
            });

            app.UseMvc();
           
            app.TestMiddlerWare();
            app.UseSwagger();
            app.UseSwaggerUi(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1.0");
            });
        }
    }
}
