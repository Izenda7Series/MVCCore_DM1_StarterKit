using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.DependencyInjection;
using MVCCoreStarterKit.Areas.Identity.Model;
using MVCCoreStarterKit.Data;

[assembly: HostingStartup(typeof(MVCCoreStarterKit.Areas.Identity.IdentityHostingStartup))]
namespace MVCCoreStarterKit.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        #region Methods
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddScoped<ApplicationUserManager, ApplicationUserManager>();
                services.AddScoped<ApplicationSignInManager, ApplicationSignInManager>();
                services.AddScoped<ApplicationRoleManager, ApplicationRoleManager>();
                services.AddIdentity<IzendaUser, IdentityRole>()
                    .AddDefaultUI(UIFramework.Bootstrap4)
                    .AddEntityFrameworkStores<ApplicationDbContext>();

                services.AddScoped<IUserClaimsPrincipalFactory<IzendaUser>, ApplicationUserClaimsPrincipalFactory>();
            });
        } 
        #endregion
    }
}