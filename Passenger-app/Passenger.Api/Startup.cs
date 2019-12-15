using System.Net.Mime;
using System.Xml;
using System.Text;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Passenger.Infrastructure.IoC.Modules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Passenger.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication;
using Passenger.Infrastructure.Services;
using Newtonsoft.Json;
using Passenger.Api.Framework;
using NLog.Extensions.Logging;
using NLog.Web;
using Passenger.Infrastructure.Mongo;

namespace Passenger.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc()
                            .AddJsonOptions(x => x.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented)
                            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
            services.AddMemoryCache();
            var jwtSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:5000",
                    ValidateAudience = false
                };
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();

            services.AddOptions();
            return new AutofacServiceProvider(ApplicationContainer);
        }
        [Obsolete]
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            loggerFactory.AddNLog();
            app.AddNLogWeb();
            env.ConfigureNLog("nlog.config");

            
            MongoConfigurator.Initialize();
            var generalSettings = app.ApplicationServices.GetService<GeneralSettings>();
            if(generalSettings.SeedData)
            {
                var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
                dataInitializer.SeedAsync();
            }
            app.UseExceptionHandler2();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
