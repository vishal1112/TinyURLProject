using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace TinyURL.Api.App_Start
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer uContainer;

        public UnityResolver(IUnityContainer UContainer)
        {
            if (UContainer == null)
            {
                throw new ArgumentException("Null Argument");
            }
            this.uContainer = UContainer;
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = uContainer.CreateChildContainer();
            return new UnityResolver(childContainer);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return uContainer.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return uContainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
        public void Dispose()
        {
            uContainer.Dispose();
        }
    }
}