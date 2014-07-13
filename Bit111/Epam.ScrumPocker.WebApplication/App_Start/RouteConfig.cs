using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Epam.ScrumPocker.WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CreateRoomRoute",
                url: "create",
                defaults: new { controller = "Room", action = "Create" }
            );

            routes.MapRoute(
                name: "Main voting",
                url: "{id}",
                defaults: new { controller = "Voting", action = "Index" }
            );   

            routes.MapRoute(
                name: "Main create room",
                url: "{controller}/{action}/{id}",  
                defaults: new { controller = "Default", action = "Index", id=UrlParameter.Optional }
            );

         

            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
            );
            */
        }
    }
}
