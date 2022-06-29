using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FortyFingers.EmptyModuleVue3.Services.ViewModels
{
    public class ModuleConfigModel
    {
        [JsonProperty("canEdit")]
        public bool CanEdit { get; set; }
        [JsonProperty("showList")]
        public bool ShowList { get; set; } = false;
        [JsonProperty("showDatatable")]
        public bool ShowDatatable { get; set; } = true;
    }
}