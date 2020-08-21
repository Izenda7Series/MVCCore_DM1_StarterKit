using Microsoft.AspNetCore.Mvc;
using MVCCoreStarterKit.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MVCCoreStarterKit.Controllers
{
    public class DashboardController : Controller
    {
        #region Methods
        /// <summary>
        /// Action for rendering a dashboard viewer.
        /// </summary>
        /// <param name="id">The dashboard ID</param>
        /// <returns>DashboardViewer View</returns>
        [Theme]
        public IActionResult DashboardViewer(string id)
        {
            var query = Request.Query;
            dynamic filters = new System.Dynamic.ExpandoObject();
            foreach (string key in query.Keys)
            {
                ((IDictionary<string, Object>)filters).Add(key, query[key]);
            }

            ViewBag.Id = id;
            ViewBag.filters = JsonConvert.SerializeObject(filters);
            return View();
        } 
        #endregion
    }
}
