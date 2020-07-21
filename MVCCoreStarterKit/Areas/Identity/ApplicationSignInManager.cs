using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MVCCoreStarterKit.Areas.Identity.Model;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.Areas.Identity
{
    public class ApplicationSignInManager : SignInManager<IzendaUser>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<IzendaUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<ApplicationSignInManager> logger,
            IAuthenticationSchemeProvider schemes)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }

        public async Task<bool> PasswordSignInAsync(string tenant, string username, string password, bool remember)
        {
            var user = await (UserManager as ApplicationUserManager).FindTenantUserAsync(tenant, username, password);

            if (user != null)
            {
                await SignInAsync(user, remember);
                return true;
            }

            return false;
        }

    }
}
