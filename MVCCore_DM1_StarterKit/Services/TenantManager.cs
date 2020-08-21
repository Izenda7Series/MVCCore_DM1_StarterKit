using MVCCoreStarterKit.Areas.Identity.Model;
using MVCCoreStarterKit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.Services
{
    public interface ITenantManager
    {
        #region Properties
        Tenant GetTenantByName(string name);

        Tenant GetTenantById(int? id);
        #endregion

        #region Methods
        Task<Tenant> SaveTenantAsync(Tenant tenant);

        List<Tenant> GetAllTenants(); 
        #endregion
    }

    public class TenantManager : ITenantManager
    {
        #region Variables
        private readonly ApplicationDbContext dbContext;
        #endregion

        #region CTOR
        public TenantManager(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        } 
        #endregion

        #region Methods
        public Tenant GetTenantByName(string name)
        {
            using (var context = dbContext)
            {
                var tenant = context.Tenants.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
                return tenant;
            }
        }

        public Tenant GetTenantById(int? id)
        {
            using (var context = dbContext)
            {
                var tenant = context.Tenants.Where(x => x.Id.Equals(id)).SingleOrDefault();
                return tenant;
            }
        }

        public List<Tenant> GetAllTenants() => dbContext.Tenants.ToList();

        public async Task<Tenant> SaveTenantAsync(Tenant tenant)
        {
            dbContext.Tenants.Add(tenant);
            await dbContext.SaveChangesAsync();

            return tenant;
        } 
        #endregion
    }
}
