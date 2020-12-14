using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCoreStarterKit.Areas.Identity.Model
{
    public class IzendaUser : IdentityUser
    {
        #region Properties
        public int? TenantId { get; set; }

        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; } 
        #endregion
    }
}
