using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCCoreStarterKit.Attributes;
using MVCCoreStarterKit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace MVCCoreStarterKit.Controllers
{
    public class HomeController : Controller
    {
        #region Variables
        private readonly ILog _logger;

        private readonly IConfiguration _configuration;
        #endregion

        #region CTOR
        public HomeController(IConfiguration configuration)
        {
            _logger = LogManager.GetLogger(System.Reflection.Assembly.GetEntryAssembly(), "MVCCoreStarterKit");
            this._configuration = configuration;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action for default landing page
        /// </summary>
        /// <returns>Index View for home page</returns>
        [Theme]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Action for rendering Izenda page for single page application
        /// </summary>
        /// <returns>Izenda View for SPA</returns>
        [Theme]
        public ActionResult Izenda()
        {
            return View();
        }

        /// <summary>
        /// Action for rendering Izenda Settings page
        /// </summary>
        /// <returns>Settings View</returns>
        [Theme]
        public ActionResult Settings()
        {
            return View();
        }

        /// <summary>
        /// Action for rendering Mixed Parts page
        /// </summary>
        /// <returns>MixedParts View</returns>
        [Theme]
        public ActionResult MixedParts()
        {
            return View();
        }

        /// <summary>
        /// Action for rendering Izenda Report Designer page
        /// </summary>
        /// <returns>ReportDesigner View</returns>
        [Theme]
        public ActionResult ReportDesigner()
        {
            return View();
        }

        /// <summary>
        /// Action for rendering Izenda Report List page
        /// </summary>
        /// <returns>Reports View</returns>
        [Theme]
        public ActionResult Reports()
        {
            return View();
        }

        /// <summary>
        /// Action for rendering Izenda Dashboard Designer page
        /// </summary>
        /// <returns>DashboardDesigner View</returns>
        [Theme]
        public ActionResult DashboardDesigner()
        {
            return View();
        }

        /// <summary>
        /// Action for rendering Izenda Dashboard List page
        /// </summary>
        /// <returns>Dashboards View</returns>
        [Theme]
        public ActionResult Dashboards()
        {
            return View();
        }

        /// <summary>
        /// Action for rendering Izenda Report Part
        /// </summary>
        /// <param name="id">report part id</param>
        /// <param name="token">token from url</param>
        /// <returns>ReportPart View</returns>
        public ActionResult ReportPart(Guid id, string token)
        {
            _logger.Debug($"ReportPart action token pulled from URL: {token}");

            ViewBag.Id = id;
            ViewBag.Token = string.IsNullOrWhiteSpace(token) ? HttpUtility.UrlEncode(Request.Cookies["access_token"]) : token;

            return View();
        }

        /// <summary>
        /// Action for rendering Izenda I-Frame from exported URL
        /// </summary>
        /// <param name="id">report id</param>
        /// <returns>IframeViewer View</returns>
        public ActionResult IframeViewer(string id)
        {
            var query = Request.Query;
            dynamic filters = new System.Dynamic.ExpandoObject();
            foreach (string key in query.Keys)
            {
                ((IDictionary<string, Object>)filters).Add(key, query[key]);
            }

            ViewBag.overridingFilterQueries = JsonConvert.SerializeObject(filters);
            ViewBag.Id = id;
            return View();
        } 
        #endregion
    }
}
