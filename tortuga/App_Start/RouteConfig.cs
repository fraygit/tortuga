using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace tortuga
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Customisations",
                url: "Dashboard/Customisations/{controller}/{action}",
                defaults: new { controller = "Document", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Organisaion",
                url: "Dashboard/{controller}/{action}",
                defaults: new { controller = "Organisation", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}