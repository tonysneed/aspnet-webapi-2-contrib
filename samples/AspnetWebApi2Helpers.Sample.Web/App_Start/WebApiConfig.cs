using System.Web.Http;
using AspnetWebApi2Helpers.Sample.Entities;
using AspnetWebApi2Helpers.Serialization;
//using AspnetWebApi2Helpers.Serialization.Protobuf;

namespace AspnetWebApi2Helpers.Sample.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonPreserveReferences();
            config.Formatters.XmlPreserveReferences();
            //config.Formatters.ProtobufPreserveReferences(typeof(Category).Assembly);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
