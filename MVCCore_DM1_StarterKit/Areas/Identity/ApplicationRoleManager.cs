using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MVCCoreStarterKit.Areas.Identity
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        #region CTOR
        public ApplicationRoleManager(IRoleStore<IdentityRole> store,
            IEnumerable<IRoleValidator<IdentityRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<IdentityRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        } 
        #endregion
    }
}
