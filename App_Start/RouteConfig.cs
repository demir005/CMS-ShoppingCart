using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMSShoppingCard
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("Shop", "Shop/{action}/{name}", new { controller = "Shop", action = "Index", name = UrlParameter.Optional }, new[] { "CMSShoppingCard.Controllers" });

            routes.MapRoute("Cart", "Cart/{action}/{id}", new { controller = "Cart", action = "Index", id = UrlParameter.Optional }, new[] { "CMSShoppingCard.Controllers" });

            routes.MapRoute("Account", "Account/{action}/{name}", new { controller = "Account", action = "Index", name = UrlParameter.Optional }, new[] { "CMSShoppingCard.Controllers" });



            routes.MapRoute("SlidebarPartial", "Pages/SlidebarPartial", new { controller = "Pages", action = "SlidebarPartial" }, new[] { "CMSShoppingCard.Controllers" });
            routes.MapRoute("PagesMenuPartial", "Pages/PagesMenuPartial", new { controller = "Pages", action = "PagesMenuPartial" }, new[] { "CMSShoppingCard.Controllers" });
            routes.MapRoute("Pages", "{page}", new { controller = "Pages", action = "Index" }, new[] { "CMSShoppingCard.Controllers" });
            routes.MapRoute("Default", "", new { controller = "Pages", action = "Index" }, new[] { "CMSShoppingCard.Controllers" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
