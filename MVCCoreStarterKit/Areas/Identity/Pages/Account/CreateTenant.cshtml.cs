using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MVCCoreStarterKit.Areas.Identity.Model;
using MVCCoreStarterKit.IzendaBoundary;
using MVCCoreStarterKit.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.Areas.Identity.Pages.Account
{
    public class CreateTenantModel : PageModel
    {
        private readonly ILogger<CreateTenantModel> _logger;

        private readonly ITenantManager _tenantManager;

        public CreateTenantModel(ILogger<CreateTenantModel> logger, ITenantManager tenantManager)
        {
            _logger = logger;
            _tenantManager = tenantManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Tenant ID")]
            public string TenantID { get; set; }


            [Required]
            [Display(Name = "Tenant Name")]
            public string TenantName { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var izendaAdminAuthToken = IzendaTokenAuthorization.GetIzendaAdminToken();
                var tenantName = Input.TenantName;
                var isTenantExist = _tenantManager.GetTenantByName(tenantName); // check user DB first

                if (isTenantExist == null)
                {
                    // try to create a new tenant at izenda DB
                    var success = await IzendaUtility.CreateTenant(tenantName, Input.TenantID, izendaAdminAuthToken);

                    if (success)
                    {
                        // save a new tenant at user DB
                        var newTenant = new Tenant() { Name = Input.TenantID };
                        await _tenantManager.SaveTenantAsync(newTenant);

                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create a tenant. Tenant already exists in Izenda Config DB.");
                        return Page();
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError(string.Empty, "Failed to create a tenant. Tenant aleady exists in application DB.");
            return Page();
        }
    }
}
