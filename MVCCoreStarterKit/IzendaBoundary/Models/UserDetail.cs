﻿using System;

namespace MVCCoreStarterKit.IzendaBoundary.Models
{
    public class UserDetail
    {
        #region Properties
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; } 
        #endregion
    }
}