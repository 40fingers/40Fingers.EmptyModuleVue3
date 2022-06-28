using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace FortyFingers.EmptyModuleVue3.Components
{
    public static class Common
    {
        public static bool IsJson(this string s)
        {
            try
            {
                var dummy = JToken.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}