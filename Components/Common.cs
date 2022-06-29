using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.ComponentModel.DataAnnotations;
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

        public static string GetTableName<T>()
        {
            var tableNameAttribute = typeof(T).GetCustomAttributes(typeof(TableNameAttribute), true).FirstOrDefault();
            if (tableNameAttribute != null && tableNameAttribute is TableNameAttribute dnAttribute)
            {
                return dnAttribute.TableName;
            }
            return null;
        }

    }
}