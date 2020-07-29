using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCCoreStarterKit.Models;

namespace MVCCoreStarterKit.Controllers.ApiController
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        #region Methods
        [HttpGet]
        [Route("validateIzendaAuthToken")]
        public UserInfo ValidateIzendaAuthToken(string access_token)
        {
            var userInfo = IzendaBoundary.IzendaTokenAuthorization.GetUserInfo(access_token);
            return userInfo;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetIzendaAccessToken")]
        public IActionResult GetIzendaAccessToken(string message)
        {
            var userInfo = IzendaBoundary.IzendaTokenAuthorization.DecryptIzendaAuthenticationMessage(message);
            var token = IzendaBoundary.IzendaTokenAuthorization.GetToken(userInfo);

            return Ok(new { Token = token });
        } 
        #endregion
    }
}
