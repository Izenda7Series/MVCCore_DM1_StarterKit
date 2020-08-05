using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MVCCoreStarterKit.Areas.Identity.Model;
using MVCCoreStarterKit.Services;
using System;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
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

        /// <summary>
        /// Login with Active Directory information.
        /// Please refer to the following link to get more information on Active Directory 
        /// https://docs.microsoft.com/en-us/windows-server/identity/ad-ds/get-started/virtual-dc/active-directory-domain-services-overview
        /// </summary>
        public async Task<bool> ADSigninAsync(string tenant, string password, bool remember)
        {
            var userName = Environment.UserName;
            var userDomainName = Environment.UserDomainName;
            var authenticationType = ContextType.Domain;
            UserPrincipal userPrincipal = null;
            bool isAuthenticated = false;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userDomainName))
            {
                using (var context = new PrincipalContext(authenticationType, Environment.UserDomainName))
                {
                    try
                    {
                        userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);

                        if (userPrincipal != null)
                        {
                            var email = userPrincipal.EmailAddress;

                            // Validate credential with Active Directory information. This is optional for authentication process.
                            // If you want check password one more time, you can check here. Otherwise, you need to remove password from parameter and skip this and set isAuthencate as true since userPrincipal is not null.
                            isAuthenticated = context.ValidateCredentials(userName, password, ContextOptions.Negotiate);

                            if (isAuthenticated)
                            {
                                using (var appUserManager = UserManager as ApplicationUserManager)
                                {
                                    // retrieve tenant information after validation process
                                    var user = await appUserManager.FindTenantUserAsync(tenant, email);

                                    if (user != null)
                                    {
                                        // now you can sign in with correct authticated user
                                        await SignInAsync(user, remember);

                                        return true;
                                    }
                                    else
                                        return false;
                                }
                            }
                            else
                                return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                        return false;
                    }

                    if (!isAuthenticated)
                        return false;

                    if (userPrincipal.IsAccountLockedOut())
                        return false;

                    if (userPrincipal.Enabled.HasValue && !userPrincipal.Enabled.Value)
                        return false;
                }
            }

            return false;
        }
    }
}
