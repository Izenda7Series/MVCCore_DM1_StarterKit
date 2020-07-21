using Izenda.BI.Framework.Models.UserManagement;
using Izenda.BI.Logic.CustomConfiguration;
using IzendaBoundary;
using MVCCoreStarterKit.Models;

namespace MVCCoreStarterKit
{
    public static class IzendaConfig
    {
        public static void RegisterLoginLogic()
        {
            //This is used for exporting only
            UserIntegrationConfig.GetAccessToken = (args) =>
            {
                return IzendaTokenAuthorization.GetToken(new UserInfo()
                {
                    UserName = args.UserName,
                    TenantUniqueName = args.TenantId
                });
            };

            UserIntegrationConfig.ValidateToken = (ValidateTokenArgs args) =>
            {
                var token = args.AccessToken;
                var user = IzendaTokenAuthorization.GetUserInfo(token);

                // TenantUniqueName corresponds to the 'TenantID' field in the IzendaTenant table
                return new ValidateTokenResult { UserName = user.UserName, TenantUniqueName = user.TenantUniqueName };
            };
        }
    }
}
