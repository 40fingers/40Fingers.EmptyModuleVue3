using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Common;
using DotNetNuke.Web.Api;
using DotNetNuke.Security;
using System.Threading;
using DotNetNuke.UI.Modules;
using DotNetNuke.Common.Utilities;
using System.Collections.Generic;
using System.Net;
using DotNetNuke.Data;
using DotNetNuke.Security.Permissions;
using FortyFingers.EmptyModuleVue3.Components.BaseClasses;
using FortyFingers.EmptyModuleVue3.Data;
using FortyFingers.EmptyModuleVue3.Services.ViewModels;
using Newtonsoft.Json.Linq;

namespace FortyFingers.EmptyModuleVue3.Services
{
    [AllowAnonymous]
    public class DatatablesController : ApiControllerBase
    {
        public DatatablesController() { }

        [HttpPost]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Processing()
        {
            var req = Request.RequestUri.Query;

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}