using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVCCoreStarterKit.Data;
using MVCCoreStarterKit.Services;
using System;
using System.Collections;
using System.IO;

namespace MVCCoreStarterKit
{
    public class Startup
    {
        #region Properties
        public IConfiguration Configuration { get; } 
        #endregion

        #region CTOR
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            foreach (DictionaryEntry env in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"{env.Key}={env.Value}");
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection()
                .SetApplicationName("Izenda")
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KeyFile")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ApplicationDbContext>();

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

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.WebRootPath, "Content")),
                RequestPath = "/api/content"
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("ReportPart", "izenda/viewer/reportpart/{id}", defaults: new { controller = "Home", action = "ReportPart" });
                endpoints.MapControllerRoute("IframeViewer", "izenda/report/iframe/{id}", defaults: new { controller = "Home", action = "IframeViewer" });
                endpoints.MapControllerRoute("ReportViewer", "izenda/report/view/{id}", defaults: new { controller = "Report", action = "ReportViewer" });
                endpoints.MapControllerRoute("DashboardViewer", "izenda/dashboard/edit/{id}", defaults: new { controller = "Dashboard", action = "DashboardViewer" });
                endpoints.MapControllerRoute("izenda", "izenda", defaults: new { controller = "Home", action = "Izenda" });
                endpoints.MapControllerRoute("izenda_settings", "izenda/settings", defaults: new { controller = "Home", action = "Settings" });
                endpoints.MapControllerRoute("izenda_new_dashboard", "izenda/dashboard/new", defaults: new { controller = "Home", action = "DashboardDesigner" });
                endpoints.MapControllerRoute("izenda_dashboard", "izenda/dashboard", defaults: new { controller = "Home", action = "Dashboards" });
                endpoints.MapControllerRoute("izenda_report", "izenda/report", defaults: new { controller = "Home", action = "Reports" });
                endpoints.MapControllerRoute("izenda_reportviewer", "izenda/reportviewer", defaults: new { controller = "Home", action = "Reports" });
                //endpoints.MapControllerRoute("izenda_reportviewerpopup", "izenda/reportviewerpopup", defaults: new { controller = "Home", action = "Izenda" });
                endpoints.MapControllerRoute("ExportManager", "izenda/myprofile", defaults: new { controller = "Home", action = "ExportManager" });
                endpoints.MapControllerRoute("izenda_dashboarddesigner", "izenda/dashboarddesigner", defaults: new { controller = "Home", action = "DashboardDesigner" });
                endpoints.MapControllerRoute("izenda_reportdesigner", "izenda/reportdesigner", defaults: new { controller = "Home", action = "ReportDesigner" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        #endregion
    }
}
