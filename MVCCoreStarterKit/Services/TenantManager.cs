using MVCCoreStarterKit.Areas.Identity.Model;
using MVCCoreStarterKit.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.Services
{
    public interface ITenantManager
    {
        Tenant GetTenantByName(string name);
        Task<Tenant> SaveTenantAsync(Tenant tenant);
    }

    public class TenantManager : ITenantManager
    {
        private readonly ApplicationDbContext dbContext;

        public TenantManager(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Tenant GetTenantByName(string name)
        {
            var tenant = dbContext.Tenants.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            return tenant;
        }


        public async Task<Tenant> SaveTenantAsync(Tenant tenant)
        {
            dbContext.Tenants.Add(tenant);
            await dbContext.SaveChangesAsync();

            return tenant;
        }
    }
}
