using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MVCCoreStarterKit.Areas.Identity.Model;
using MVCCoreStarterKit.IzendaBoundary;
using MVCCoreStarterKit.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.Areas.Identity.Pages.Account
{
    public class CreateUserModel : PageModel
    {
        #region Variables
        private readonly ApplicationUserManager _userManager;

        private readonly ApplicationRoleManager _roleManager;

        private readonly ILogger<CreateUserModel> _logger;

        private readonly ITenantManager _tenantManager;

        public SelectList TenantSelectList;

        public SelectList RoleSelectList;
        #endregion

        public CreateUserModel(ApplicationUserManager userManager, ApplicationRoleManager roleManager, ILogger<CreateUserModel> logger, ITenantManager tenantManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _tenantManager = tenantManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Tenant*")]
            public int? SelectedTenantId { get; set; }

            [Display(Name = "Role")]
            public string SelectedRole { get; set; }

            [Display(Name = "Is Admin")]
            public bool IsAdmin { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "User ID")]
            public string UserID { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
        }

        public void OnGet()
        {
            var izendaAdminAuthToken = IzendaTokenAuthorization.GetIzendaAdminToken();
            var tenants = _tenantManager.GetAllTenants().Select(t => new { t.Name, t.Id }).ToList();
               
            TenantSelectList = new SelectList(tenants, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                int? tenantId = null;

                if (Input.SelectedTenantId != null)
                {
                    tenantId = Input.SelectedTenantId;

                    Input.IsAdmin = false;
                }

                var user = new IzendaUser
                {
                    UserName = Input.UserID,
                    Email = Input.UserID,
                    Tenant_Id = tenantId,
                };

                var result = await _userManager.CreateAsync(user); // Save new user into client DB

                if (result.Succeeded) // if successful, then start creating a user at Izenda DB
                {
                    var assignedRole = !string.IsNullOrEmpty(Input.SelectedRole) ? Input.SelectedRole : "Employee"; // set default role if required. As an example, Employee is set by default

                    var isRoleExisting = _roleManager.FindByNameAsync(assignedRole); // check assigned role exist in client DB. if not, assigned role is null

                    if (isRoleExisting == null)
                    {
                        try
                        {
                            await _roleManager.CreateAsync(new Microsoft.AspNetCore.Identity.IdentityRole(assignedRole));
                            result = await _userManager.AddToRoleAsync(user, assignedRole);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e);
                        }
                    }

                    if (result.Succeeded)
                    {
                        var izendaAdminAuthToken = IzendaTokenAuthorization.GetIzendaAdminToken();
                        user.Tenant = _tenantManager.GetTenantById(Input.SelectedTenantId); // set client DB application user's tenant
                        var tenantName = user.Tenant.Name;

                        // Create a new user at Izenda DB
                        var success = await IzendaUtility.CreateIzendaUser(
                            tenantName,
                            Input.UserID,
                            Input.LastName,
                            Input.FirstName,
                            Input.IsAdmin,
                            assignedRole,
                            izendaAdminAuthToken);

                        if (success)
                            return LocalRedirect(returnUrl);
                    }
                    ModelState.AddModelError(string.Empty, "Failed to create a new user. User already exists in DB.");
                    return Page();
                }
            }
            ModelState.AddModelError(string.Empty, "Failed to create a new user. Invalid model.");
            return Page();
        }

        public async Task<IActionResult> OnPostListAsync(string selectedTenant)
        {
            var adminToken = IzendaTokenAuthorization.GetIzendaAdminToken();

            var izendaTenant = await IzendaUtility.GetIzendaTenantByName(selectedTenant, adminToken);
            var roleDetailsByTenant = await IzendaUtility.GetAllIzendaRoleByTenant(izendaTenant?.Id ?? null, adminToken);

            var roles = roleDetailsByTenant.Select(r => new { r.Id, r.Name }).ToList();
            RoleSelectList = new SelectList(roles, "Id", "Name");

            return new JsonResult(RoleSelectList);
        }
    }
}
