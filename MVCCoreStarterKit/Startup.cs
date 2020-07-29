using Izenda.BI.API.Bootstrappers;
using Izenda.BI.Framework.Constants;
using Izenda.BI.Utility.AppSetting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MVCCoreStarterKit.Data;
using MVCCoreStarterKit.Services;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Owin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVCCoreStarterKit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            IzendaConfig.RegisterLoginLogic();
            Izenda.BI.Logging.Log4Net.LogConfiguration.Configure();
            var temp = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry env in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"{env.Key}={env.Value}");
            }
            //if (File.Exists("izendadb.config"))
            //{
            //    Console.WriteLine($"in file: {File.ReadAllText("izendadb.config")}");
            //}
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection()
                .SetApplicationName("Izenda")
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KeyFile")));
                
            var appSettingSection = this.Configuration.GetSection("AppSettings");
            var appSetting = services.Configure<AppSettings>(appSettingSection)
                                     .BuildServiceProvider()
                                     .GetService<IOptions<AppSettings>>();
            Configuration.GetSection("AppSettings").Bind(appSetting);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITenantManager, TenantManager>();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.WebRootPath, "Content")),
                RequestPath = "/api/content"
            });
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute("ReportPart", "izenda/viewer/reportpart/{id}", defaults: new { controller = "Home", action = "ReportPart" });
                routes.MapRoute("IframeViewer", "izenda/report/iframe/{id}", defaults: new { controller = "Home", action = "IframeViewer" });
                routes.MapRoute("ReportViewer", "izenda/report/view/{id}", defaults: new { controller = "Report", action = "ReportViewer" });
                routes.MapRoute("DashboardViewer", "izenda/dashboard/edit/{id}", defaults: new { controller = "Dashboard", action = "DashboardViewer" });
                routes.MapRoute("izenda", "izenda", defaults: new { controller = "Home", action = "Izenda" });
                routes.MapRoute("izenda_settings", "izenda/settings", defaults: new { controller = "Home", action = "Izenda" });
                routes.MapRoute("izenda_new", "izenda/new", defaults: new { controller = "Home", action = "Izenda" });
                routes.MapRoute("izenda_dashboard", "izenda/dashboard", defaults: new { controller = "Home", action = "Izenda" });
                routes.MapRoute("izenda_report", "izenda/report", defaults: new { controller = "Home", action = "Izenda" });
                routes.MapRoute("izenda_reportviewer", "izenda/reportviewer", defaults: new { controller = "Home", action = "Izenda" });
                routes.MapRoute("izenda_reportviewerpopup", "izenda/reportviewerpopup", defaults: new { controller = "Home", action = "Izenda" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseOwin(x => x.UseNancy(opt => opt.Bootstrapper = new CustomBootstraper()));
        }
    }

    public class CustomBootstraper : IzendaBootstraper
    {
        protected override IEnumerable<ModuleRegistration> Modules
        {
            get
            {
                var nancyType = typeof(INancyModule);
                var moduleTypes = typeof(IzendaBootstraper).Assembly.GetTypes()
                    .Where(x => !x.IsAbstract && x.GetInterfaces().Contains(nancyType))
                    .Select(x => new ModuleRegistration(x));
                return base.Modules.Concat(moduleTypes);
            }
        }
    }
}
