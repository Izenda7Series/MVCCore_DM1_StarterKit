using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MVCCoreStarterKit.Areas.Identity.Model;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.Areas.Identity
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<IzendaUser>
    {
        public ApplicationUserClaimsPrincipalFactory(ApplicationUserManager userManager,
            IOptions<IdentityOptions> options)
            : base(userManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IzendaUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            var tenant = user.Tenant;
            if (user.Tenant != null)
            {
                identity.AddClaims(new[] {
                    new Claim("tenantName",tenant.Name),
                    new Claim("tenantId",tenant.Id.ToString()),
                });
            }
            var role = await UserManager.GetRolesAsync(user);
            identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.FirstOrDefault()));

            return identity;
        }
    }
}
