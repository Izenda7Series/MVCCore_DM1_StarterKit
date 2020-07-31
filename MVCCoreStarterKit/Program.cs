﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MVCCoreStarterKit
{
    public class Program
    {
        #region Methods
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>(); 
        #endregion
    }
}
