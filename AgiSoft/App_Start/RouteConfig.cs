using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AgiSoft {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AdminRole",
                url: "Admin/Edit/{type}",
                defaults: new { controller = "Admin", action = "RolesEdit", type = "group" }
                );

            routes.MapRoute(
                name: "MemberHome",
                url: "Home",
                defaults: new { controller = "Home", action = "Member" }
                );

            routes.MapRoute(
                name: "AccountHome",
                url: "Account",
                defaults: new { controller = "Account", action = "Login" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}