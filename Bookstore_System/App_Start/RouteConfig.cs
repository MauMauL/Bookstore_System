using System.Web.Mvc;
using System.Web.Routing;

namespace Bookstore_System.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Livro", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
