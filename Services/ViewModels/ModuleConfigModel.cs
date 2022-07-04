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
        // TODO: Make this a setting
        public bool ShowList { get; set; } = false;
        [JsonProperty("showDatatable")]
        // TODO: Make this a setting
        public bool ShowDatatable { get; set; } = true;
        [JsonProperty("processDatatableServerside")]
        // TODO: Make this a setting
        public bool ProcessDatatableServerside { get; set; } = true;
    }
}