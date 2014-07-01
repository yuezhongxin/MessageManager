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
                "Message/Show/{id}",
                new { controller = "Message", action = "Show", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Message", action = "Compose" }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{userName}",
            //    defaults: new { controller = "Index", action = "Index", userName = UrlParameter.Optional }
            //);
        }
    }
}