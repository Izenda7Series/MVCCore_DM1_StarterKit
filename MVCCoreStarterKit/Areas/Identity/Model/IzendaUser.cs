using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCoreStarterKit.Areas.Identity.Model
{
    public class IzendaUser : IdentityUser
    {
        public int? Tenant_Id { get; set; }

        [ForeignKey("Tenant_Id")]
        public Tenant Tenant { get; set; }
    }
}
