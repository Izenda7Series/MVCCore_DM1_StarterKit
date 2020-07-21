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
        private static readonly Lazy<IzendaSkinHelper> lazy =
        new Lazy<IzendaSkinHelper>(() => new IzendaSkinHelper());
        private string productVersion;
        private ILog logger;

        public static IzendaSkinHelper Instance { get { return lazy.Value; } }


        public string ProductVersion
        {
            get
            {
                if (Instance.productVersion == null)
                    Instance.productVersion = GetCurrentProductVersion();

                return Instance.productVersion;
            }
        }

        private IzendaSkinHelper()
        {
            logger = LogManager.GetLogger(System.Reflection.Assembly.GetEntryAssembly(), "MVCCoreStarterKit");
        }

        private string GetCurrentProductVersion()
        {
            var hostingEnvironment = new HttpContextAccessor().HttpContext.RequestServices.GetService(typeof(IHostingEnvironment)) as HostingEnvironment;
            var contentRootPath = hostingEnvironment.ContentRootPath;
            var apiAssemblyName = "Izenda.Synergy.WebAPICore.dll";
            var izendaApiLib = hostingEnvironment.IsDevelopment() ? @"\bin\Debug\netcoreapp2.2\" : @"\";
            var fullIzendaApiPath = $"{contentRootPath}{izendaApiLib}{apiAssemblyName}";
            logger.Info(fullIzendaApiPath);
            try
            {
                return FileVersionInfo.GetVersionInfo(fullIzendaApiPath)?.ProductVersion;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
