using Izenda.BI.Framework.Models;
using Izenda.BI.Framework.Models.DBStructure;
using Izenda.BI.Logic.CustomConfiguration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MVCCoreStarterKit.Areas.Identity.Model;
using MVCCoreStarterKit.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ApplicationSignInManager signInManager;
        private readonly ApplicationUserManager userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;
        private readonly ITenantManager tenantManager;

        public RegisterModel(
            ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ITenantManager tenantManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
            this.tenantManager = tenantManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Tenant")]
            public string Tenant { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var tenant = await HandleTenant(Input.Tenant);
                var roleName = IsSystemTenant(tenant.Name) ? "Administrator" : "Manager";

                var user = new IzendaUser { Tenant_Id = tenant.Id, UserName = Input.Email, Email = Input.Email };
                var result = await userManager.CreateAsync(user, Input.Password);
                await userManager.AddToRoleAsync(user, roleName);

                if (result.Succeeded)
                {
                    logger.LogInformation("User created a new account with password.");
                    //determine tenant
                    Tenants izendaTenant = null;
                    if (!IsSystemTenant(tenant.Name))
                    {
                        izendaTenant = new Tenants();
                        izendaTenant.Active = true;
                        izendaTenant.Deleted = false;

                        izendaTenant.Name = tenant.Name;
                        izendaTenant.TenantID = tenant.Name;
                        TenantIntegrationConfig.AddOrUpdateTenant(izendaTenant);
                    }

                    //determine roles
                    var roleDetail = new RoleDetail()
                    {
                        Name = roleName,
                        TenantUniqueName = tenant.Name,
                        Active = true,
                        Permission = new Izenda.BI.Framework.Models.Permissions.Permission(),
                    };

                    var izendaUser = new UserDetail()
                    {
                        UserName = user.Email,
                        EmailAddress = user.Email,
                        FirstName = "John", //todo fix this
                        LastName = "Doe",
                        TenantDisplayId = izendaTenant?.Name,
                        SystemAdmin = IsSystemTenant(tenant.Name),
                        Deleted = false,
                        Active = true,
                        Roles = new List<Role>()
                    };

                    izendaUser.Roles.Add(new Role()
                    {
                        Name = roleDetail.Name
                    });

                    RoleIntegrationConfig.AddOrUpdateRole(roleDetail);
                    UserIntegrationConfig.AddOrUpdateUser(izendaUser);

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task<Tenant> HandleTenant(string tenantName)
        {
            var existingTenant = tenantManager.GetTenantByName(tenantName);
            if (existingTenant != null)
                return existingTenant;
            return await tenantManager.SaveTenantAsync(new Tenant { Name = tenantName });
        }

        private bool IsSystemTenant(string tenantName)
        {
            return tenantName.Equals("System", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
