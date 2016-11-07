using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TinyURL.Api.Utility;
using TinyURL.DataStore.Services;
using Unity.WebApi;

namespace TinyURL.Api.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ITinyURLGenerator, TinyURLGenerator>(new HierarchicalLifetimeManager());
            container.RegisterType<ITinyURLRepository, TinyURLRepository>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}