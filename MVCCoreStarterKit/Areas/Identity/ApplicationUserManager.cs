using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MVCCoreStarterKit.Areas.Identity.Model;
using MVCCoreStarterKit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.Areas.Identity
{
    public class ApplicationUserManager : UserManager<IzendaUser>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ApplicationRoleManager roleManager;
        public ApplicationUserManager(IUserStore<IzendaUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<IzendaUser> passwordHasher,
            IEnumerable<IUserValidator<IzendaUser>> userValidators,
            IEnumerable<IPasswordValidator<IzendaUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<ApplicationUserManager> logger,
            ApplicationDbContext dbContext,
            ApplicationRoleManager roleManager)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.dbContext = dbContext;
            this.roleManager = roleManager;
        }

        public async Task<IzendaUser> FindTenantUserAsync(string tenant, string username, string password)
        {
            IzendaUser user = null;

            if (!string.IsNullOrWhiteSpace(tenant))
            {
                user = await dbContext.Users
                  .Include(x => x.Tenant)
                  .Where(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                  .Where(x => x.Tenant.Name.Equals(tenant, StringComparison.InvariantCultureIgnoreCase))
                  .SingleOrDefaultAsync();
            }
            else
            {
                user = await dbContext.Users
                    .Include(x=> x.Tenant)
                    .Where(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                    .Where(x => !x.Tenant_Id.HasValue)
                    .SingleOrDefaultAsync();
            }

            if (await CheckPasswordAsync(user, password))
                return user;

            return user;
        }

        /// <summary>
        /// Overload FindTenantUserAsync. In case of Active Directory authentication, password is not required for finding tenant
        /// </summary>
        public async Task<IzendaUser> FindTenantUserAsync(string tenant, string username)
        {
            IzendaUser user = null;

            if (!string.IsNullOrWhiteSpace(tenant))
            {
                user = await dbContext.Users
                  .Include(x => x.Tenant)
                  .Where(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                  .Where(x => x.Tenant.Name.Equals(tenant, StringComparison.InvariantCultureIgnoreCase))
                  .SingleOrDefaultAsync();
            }
            else
            {
                user = await dbContext.Users
                    .Include(x => x.Tenant)
                    .Where(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                    .Where(x => !x.Tenant_Id.HasValue)
                    .SingleOrDefaultAsync();
            }

            return user;
        }

        public override async Task<IdentityResult> AddToRoleAsync(IzendaUser user, string role)
        {
            var roleDetail = await roleManager.FindByNameAsync(role);
            if (roleDetail == null)
            {
                roleDetail = new IdentityRole(role);
                await roleManager.CreateAsync(roleDetail);
            }

            return await base.AddToRoleAsync(user, role);
        }
    }
}
