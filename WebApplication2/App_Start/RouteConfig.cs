using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Details",
                url: "User/Details",
                defaults: new { controller = "User", action = "Details" });

            routes.MapRoute(
                name: "EditUserDetails",
                url: "Admin/EditUserDetails",
                defaults: new { controller = "Admin", action = "EditUserDetails" }
);

            routes.MapRoute(
                name: "UserDetails",
                url: "Admin/UserDetails/{userId}",
                defaults: new { controller = "Admin", action = "UserDetails", userId = UrlParameter.Optional }
);



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
