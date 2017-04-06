using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using WAF.Presentation.Web.Routing;

namespace Homepage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Standard MVC Template routing here:
            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */


            routes.MapRoute
            (
               "Navigation",
               "Navigation/{action}/{id}",
               new { controller = "Navigation", action = "Index", id = UrlParameter.Optional }
            );

            // Standard Webnodes routing here:
            routes.MapWebnodesRoute("WAFNode", "{*address}", new { controller = "Article", action = "Index", address = UrlParameter.Optional }).RouteHandler = new WAFRouteHandler();

        }
    }
}
