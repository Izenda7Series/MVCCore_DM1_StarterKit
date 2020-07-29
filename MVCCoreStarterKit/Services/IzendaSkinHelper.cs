using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;

namespace MVCCoreStarterKit.Services
{
    public sealed class IzendaSkinHelper
    {
        #region Variables
        private static readonly Lazy<IzendaSkinHelper> _lazy = new Lazy<IzendaSkinHelper>(() => new IzendaSkinHelper());
        private string _productVersion;
        private readonly ILog _logger;
        #endregion

        #region Properties
        public static IzendaSkinHelper Instance { get { return _lazy.Value; } }

        public string ProductVersion
        {
            get
            {
                if (Instance._productVersion == null)
                    Instance._productVersion = GetCurrentProductVersion();

                return Instance._productVersion;
            }
        }
        #endregion

        #region Singleton CTOR 
        private IzendaSkinHelper()
        {
            _logger = LogManager.GetLogger(System.Reflection.Assembly.GetEntryAssembly(), "MVCCoreStarterKit");
        }
        #endregion

        #region Methods
        private string GetCurrentProductVersion()
        {
            var hostingEnvironment = new HttpContextAccessor().HttpContext.RequestServices.GetService(typeof(IHostingEnvironment)) as HostingEnvironment;
            var contentRootPath = hostingEnvironment.ContentRootPath;
            var apiAssemblyName = "Izenda.Synergy.WebAPICore.dll";
            var izendaApiLib = hostingEnvironment.IsDevelopment() ? @"\bin\Debug\netcoreapp2.2\" : @"\";
            var fullIzendaApiPath = $"{contentRootPath}{izendaApiLib}{apiAssemblyName}";
            _logger.Info(fullIzendaApiPath);
            try
            {
                return FileVersionInfo.GetVersionInfo(fullIzendaApiPath)?.ProductVersion;
            }
            catch
            {
                return string.Empty;
            }
        } 
        #endregion
    }
}
