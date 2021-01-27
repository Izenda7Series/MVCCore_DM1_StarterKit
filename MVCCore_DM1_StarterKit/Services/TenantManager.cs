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
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region CTOR
        public TenantManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public Tenant GetTenantByName(string name) => _dbContext.Tenants.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();

        public Tenant GetTenantById(int? id) => _dbContext.Tenants.Where(x => x.Id.Equals(id)).SingleOrDefault();

        public List<Tenant> GetAllTenants() => _dbContext.Tenants.ToList();

        public async Task<Tenant> SaveTenantAsync(Tenant tenant)
        {
            _dbContext.Tenants.Add(tenant);
            await _dbContext.SaveChangesAsync();

            return tenant;
        }
        #endregion
    }
}
