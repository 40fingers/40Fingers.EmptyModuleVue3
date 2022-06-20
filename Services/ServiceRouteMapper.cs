
using DotNetNuke.Web.Api;
using System.Web.Http;

namespace FortyFingers.EmptyModuleVue3.Services
{
    public class ServiceRouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                moduleFolderName: "40Fingers/EmptyModuleVue3",
                routeName: "default",
                url: "{controller}/{action}/{itemId}",
                defaults: new { itemId = RouteParameter.Optional },
                namespaces: new[] { "FortyFingers.EmptyModuleVue3.Services" });
        }
    }

}