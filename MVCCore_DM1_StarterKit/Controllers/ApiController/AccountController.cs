using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCCoreStarterKit.IzendaBoundary;
using MVCCoreStarterKit.Models.User;

namespace MVCCoreStarterKit.Controllers.ApiController
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        #region Methods
        /// <summary>
        /// Route for AuthValidateAccessTokenUrl from Izenda configuration database.
        /// </summary>
        /// <param name="access_token">Access token to validate</param>
        /// <returns>Deserialized UserInfo from token</returns>
        [HttpGet]
        [Route("validateIzendaAuthToken")]
        public UserInfo ValidateIzendaAuthToken(string access_token)
        {
            var userInfo = IzendaTokenAuthorization.GetUserInfo(access_token);
            return userInfo;
        }

        /// <summary>
        /// Route for AuthGetAccessTokenUrl from Izenda configuration database.
        /// </summary>
        /// <param name="message">RSA encrypted message from schedules/subscriptions</param>
        /// <returns>Token containing UserInfo</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetIzendaAccessToken")]
        public IActionResult GetIzendaAccessToken(string message)
        {
            var userInfo = IzendaTokenAuthorization.DecryptIzendaAuthenticationMessage(message);
            var token = IzendaTokenAuthorization.GetToken(userInfo);

            return Ok(new { Token = token });
        } 
        #endregion
    }
}
