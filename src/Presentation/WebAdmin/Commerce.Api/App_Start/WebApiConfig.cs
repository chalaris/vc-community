﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace VirtoCommerce.Web.Api
{
    using Newtonsoft.Json;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            json.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AdminItems",
                routeTemplate: "api/items",
                defaults: new { controller = "Items" }
            );

            config.Routes.MapHttpRoute(
                name: "AdminItem",
                routeTemplate: "api/item",
                defaults: new { controller = "Item" }
            );
        }
    }
}
