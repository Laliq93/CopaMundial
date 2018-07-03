using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CopaMundialAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes ( );

            config.Routes.MapHttpRoute (
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var enableCorsAttribute = new EnableCorsAttribute ( "*",
                                   "Origin, Content-Type, Accept",
                                   "GET, PUT, POST, DELETE, OPTIONS" );

            config.EnableCors ( enableCorsAttribute );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add ( new MediaTypeHeaderValue ( "application/json" ) );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

        }
    }
}
