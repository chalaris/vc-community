using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace VirtoCommerce.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AdminItems",
                routeTemplate: "api/items",
                defaults: new { controller = "Items" }
            );
        }
    }
}
