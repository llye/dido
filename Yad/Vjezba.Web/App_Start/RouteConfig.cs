using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vjezba.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Custom_Contact",
                url: "kontakt-forma",
                defaults: new { controller = "Home", action = "Contact" }
            );

            routes.MapRoute(
               name: "Custom_About",
               url: "o-aplikaciji/{lang}",
               defaults: new { controller = "Home", action = "About" },
               constraints: new { lang = @"[a-z]{2}" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
