using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Dashboard",
                url: "{controller}/{action}",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "ProductList",
                url: "{controller}/{action}",
                defaults: new { controller = "Product", action = "Index" }
            );

            routes.MapRoute(
                name: "ProductAdd",
                url: "{controller}/{action}",
                defaults: new { controller = "Product", action = "Add" }
            );

            routes.MapRoute(
                name: "Products",
                url: "{controller}/{action}",
                defaults: new { controller = "Product", action = "Products" }
            );

            routes.MapRoute(
                name: "Profile",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "UserProfile" }
            );

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}",
                defaults: new { controller = "Login", action = "Index" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Logout" }
            );

            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}",
                defaults: new { controller = "Register", action = "Index" }
            );
        }
    }
}
