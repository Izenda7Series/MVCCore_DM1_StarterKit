﻿using System;

namespace MVCCoreStarterKit.Models.Role
{
    public class RoleDetail : RoleInfo
    {
        #region Properties
        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public Guid? TenantId { get; set; }

        public bool NotAllowSharing { get; set; }
        #endregion
    }
}
