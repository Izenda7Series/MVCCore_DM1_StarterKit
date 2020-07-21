using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace MVCCoreStarterKit.Attributes
{
    public class ThemeAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
            (context.Controller as Controller).ViewBag.izendaCssPath = ResolveThemePath(context);
        }

        private string ResolveThemePath(ResultExecutingContext context)
        {
            var hostingEnvironment = context.HttpContext.RequestServices.GetService(typeof(IHostingEnvironment)) as IHostingEnvironment;
            var webRootPath = hostingEnvironment.WebRootPath;

            var identity = (ClaimsIdentity)context.HttpContext.User?.Identity;
            var tenantName = identity?.FindFirst("tenantName")?.Value;

            //Using tenantId, identify location of folder where the css resides for the given tenant and build path to CSS.
            var path = tenantName == null ? "" : string.Format("/Content/{0}/izenda-{1}.css", tenantName.ToUpper(), tenantName.ToLower());

            if (!string.IsNullOrWhiteSpace(path))
            {
                if (!System.IO.File.Exists($"{webRootPath}{path}"))
                {
                    path = string.Empty;
                }
            }

            return path;
        }
    }
}
