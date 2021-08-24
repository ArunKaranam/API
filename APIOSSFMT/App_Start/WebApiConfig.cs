using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using static APIOSSFMT.WebApiApplication;

namespace APIOSSFMT
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           
           
            //Second Way
            config.Formatters.Add(new CustomJsonFormatter());
            //first Way
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            //CONTENT NEGOTIATION
            // Indent JSON Data
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;
            //Camel case Indent of Pascal case
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

        }
    }
}
