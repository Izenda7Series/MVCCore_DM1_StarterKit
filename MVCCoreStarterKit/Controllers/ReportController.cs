using Microsoft.AspNetCore.Mvc;
using MVCCoreStarterKit.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MVCCoreStarterKit.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Theme]
        public ActionResult ReportViewer(string id)
        {
            var query = Request.Query;
            dynamic filters = new System.Dynamic.ExpandoObject();
            foreach (string key in query.Keys)
            {
                ((IDictionary<string, Object>)filters).Add(key, query[key]);
            }

            ViewBag.overridingFilterQueries = JsonConvert.SerializeObject(filters); ;
            ViewBag.Id = id;
            return View();
        }

        [Theme]
        public ActionResult ReportParts()
        {
            return View();
        }
    }
}