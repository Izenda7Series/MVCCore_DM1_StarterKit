using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCCoreStarterKit.Areas.Identity.Model;

namespace MVCCoreStarterKit.Data
{
    public class ApplicationDbContext : IdentityDbContext<IzendaUser>
    {
        #region Properties
        public DbSet<Tenant> Tenants { get; set; } 
        #endregion

        #region CTOR
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        } 
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        } 
        #endregion
    }
}
