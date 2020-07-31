using MVCCoreStarterKit.Areas.Identity.Model;
using MVCCoreStarterKit.Data;
using MVCCoreStarterKit.IzendaBoundary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCCoreStarterKit.IzendaBoundary
{
    public class IzendaUtility
    {
        /// <summary>
        /// Get all Izenda Roles by tenant
        /// For more information, please refer to https://www.izenda.com/docs/ref/api_role.html#get-role-all-tenant-id
        /// </summary>
        public static async Task<IList<RoleDetail>> GetAllIzendaRoleByTenant(Guid? tenantId, string authToken)
        {
            var roleList = await WebAPIService.Instance.GetAsync<IList<RoleDetail>>("/role/all/" + (tenantId.HasValue ? tenantId.ToString() : null), authToken);

            return roleList;
        }
    }
}