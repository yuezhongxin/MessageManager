using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MessageManager.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "ShowMessageRoute",
                "Message/Show/{ID}",
                new { controller = "Message", action = "Show", ID = UrlParameter.Optional } 
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{userName}",
                defaults: new { controller = "Index", action = "Index", userName = UrlParameter.Optional }
            );
            
        }
    }
}