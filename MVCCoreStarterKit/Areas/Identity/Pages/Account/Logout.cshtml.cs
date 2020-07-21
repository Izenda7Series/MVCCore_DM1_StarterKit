using Izenda.BI.Logic.CustomConfiguration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MVCCoreStarterKit.Areas.Identity.Model;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IzendaUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<IzendaUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var username = identity.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            var tenantName = identity.FindFirst("tenantName")?.Value;

            UserIntegrationConfig.LogOff(username, tenantName);

            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
    }
}