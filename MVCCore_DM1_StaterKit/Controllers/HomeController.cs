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

        [Theme]
        public ActionResult Izenda()
        {
            return View();
        }

        [Theme]
        public ActionResult Settings()
        {
            return View();
        }
        [Theme]

        public ActionResult MixedParts()
        {
            return View();
        }

        [Theme]
        public ActionResult ReportDesigner()
        {
            return View();
        }

        [Theme]
        public ActionResult Reports()
        {
            return View();
        }

        [Theme]
        public ActionResult DashboardDesigner()
        {
            return View();
        }

        [Theme]
        public ActionResult Dashboards()
        {
            return View();
        }

        /// <summary>
        /// Render Report part
        /// </summary>
        /// <param name="id">report part id</param>
        /// <param name="token">token from url</param>
        /// <returns></returns>
        public ActionResult ReportPart(Guid id, string token)
        {
            _logger.Debug($"ReportPart action token pulled from URL: {token}");

            ViewBag.Id = id;
            ViewBag.Token = string.IsNullOrWhiteSpace(token) ? HttpUtility.UrlEncode(Request.Cookies["access_token"]) : token;

            return View();
        }

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
