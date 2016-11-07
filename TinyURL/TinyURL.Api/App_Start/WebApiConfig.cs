using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TinyURL.Api.App_Start;
using TinyURL.Api.Utility;
using TinyURL.DataStore.Services;

namespace TinyURL.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //Web Api DI registration
            var uContainer = new UnityContainer();
            uContainer.RegisterType<ITinyURLGenerator, TinyURLGenerator>(new HierarchicalLifetimeManager());
            uContainer.RegisterType<ITinyURLRepository, TinyURLRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(uContainer);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                 routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
