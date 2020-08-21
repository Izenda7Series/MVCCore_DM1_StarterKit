using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVCCoreStarterKit.Controllers.ApiController
{
    public class UserController : Controller
    {
        #region Methods
        /// <summary>
        /// Generate a token containing encrypted UserInfo for an Izenda user.
        /// </summary>
        /// <returns>Access token for a user</returns>
        [HttpGet]
        [Authorize]
        public JsonResult GenerateToken()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var username = identity.FindFirst(ClaimsIdentity.DefaultNameClaimType);
            var tenantName = identity.FindFirst("tenantName");

            var user = new Models.User.UserInfo { UserName = username?.Value, TenantUniqueName = tenantName?.Value };
            var token = IzendaBoundary.IzendaTokenAuthorization.GetToken(user);
            return Json(new { token });
        }

        /// <summary>
        /// Get current tenant
        /// </summary>
        /// <returns>Current tenant info</returns>
        [HttpGet]
        public JsonResult GetCurrentTenant()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var tenantName = identity.FindFirst("tenantName");
            var tenantId = identity.FindFirst("tenantId");

            return Json(new { tenantName = tenantName?.Value, tenantId = tenantId?.Value });
        } 
        #endregion
    }
}