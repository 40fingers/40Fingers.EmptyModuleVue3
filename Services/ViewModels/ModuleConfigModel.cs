using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FortyFingers.EmptyModuleVue3.Services.ViewModels
{
    public class ModuleConfigModel
    {
        public bool CanEdit { get; set; }
        public bool ShowList { get; set; } = false;
        public bool ShowDatatable { get; set; } = true;
    }
}