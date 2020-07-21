using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVCCoreStarterKit.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Authorize]
        public JsonResult GenerateToken()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var username = identity.FindFirst(ClaimsIdentity.DefaultNameClaimType);
            var tenantName = identity.FindFirst("tenantName");

            var user = new Models.UserInfo { UserName = username?.Value, TenantUniqueName = tenantName?.Value };
            var token = IzendaBoundary.IzendaTokenAuthorization.GetToken(user);
            return Json(new { token });
        }


        [HttpGet]
        public JsonResult GetCurrentTenant()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var tenantName = identity.FindFirst("tenantName");
            var tenantId = identity.FindFirst("tenantId");

            return Json(new { tenantName = tenantName?.Value, tenantId = tenantId?.Value });
        }
    }
}