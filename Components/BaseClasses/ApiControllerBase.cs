using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using DotNetNuke.Web.Api;
using FortyFingers.EmptyModuleVue3.Data;
using Newtonsoft.Json.Linq;

namespace FortyFingers.EmptyModuleVue3.Components.BaseClasses
{
    public class ApiControllerBase : DnnApiController
    {
        public T ContentJ<T>() where T : JToken
        {
            // get content from the request into a string
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;

            // see if it's actually JSON
            if (!jsonContent.IsJson())
            {
                throw new Exception($"Request body is not valid JSON");
            }

            // Parse the json string
            var jtoken = JToken.Parse(jsonContent);
            // see if it's the correct type
            if (typeof(T) == typeof(JToken) ||
                (jtoken.Type == JTokenType.Array && typeof(T) == typeof(JArray)) ||
                (jtoken.Type == JTokenType.Object && typeof(T) == typeof(JObject)))
            {
                // we can safely return it
                return (T)jtoken;
            }
            else
            {
                throw new Exception($"Request body is not of type {typeof(T).Name}");
            }
        }

    }
}