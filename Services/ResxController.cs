using System;
using System.Net.Http;
using System.Web;
using DotNetNuke.Security;
using DotNetNuke.Services.Localization;
using DotNetNuke.Web.Api;
using FortyFingers.EmptyModuleVue3.Components.BaseClasses;
using Newtonsoft.Json.Linq;
using System.Resources;
using System.Web.Http;
using System.Xml;

namespace FortyFingers.EmptyModuleVue3.Services
{
    [SupportedModules("40F EmptyModuleVue3")]
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
    public class ResxController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetResx")]
        public HttpResponseMessage GetResx(string filename)
        {
            var resx = new JObject();

            var resxRoot = $"~\\DesktopModules\\40Fingers\\EmptyModuleVue3\\App_LocalResources\\{filename}.resx";
            var filepath = HttpContext.Current.Server.MapPath(resxRoot);
            var resxDoc = new XmlDocument();
            resxDoc.Load(filepath);

            foreach (XmlNode dataNode in resxDoc.DocumentElement.SelectNodes("/root/data"))
            {
                var key = dataNode.Attributes["name"].Value;
                var val = Localization.GetString(key.ToString(), resxRoot);

                if (key.EndsWith(".text", StringComparison.InvariantCultureIgnoreCase)) key = key.Substring(0, key.Length - 5);
                key = key.Replace(".", "_");

                resx.Add(key, val);
            }

            return Request.CreateResponse(resx);
        }

    }
}