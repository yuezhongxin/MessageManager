using System.Web.Mvc;
using System.Web.Routing;

namespace MessageManager.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "ShowMessageRoute",
            //    "Message/ReadMessageSender/{id}",
            //    new { controller = "Message", action = "Show", id = UrlParameter.Optional }
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Message", action = "Compose", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{userName}",
            //    defaults: new { controller = "Index", action = "Index", userName = UrlParameter.Optional }
            //);
        }
    }
}