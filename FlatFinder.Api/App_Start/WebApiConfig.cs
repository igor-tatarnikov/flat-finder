using System.Web.Http;

namespace FlatFinder.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ControllerOnly",
                routeTemplate: "api/{controller}"
            );

            config.Routes.MapHttpRoute(
                name: "ControllerAndId",
                routeTemplate: "api/{controller}/{id}",
                defaults: null,
                constraints: new { id = @"^\d+$" } // all digits
            );

            config.Routes.MapHttpRoute(
                name: "ControllerAction",
                routeTemplate: "api/{controller}/{action}"
            );
        }
    }
}
