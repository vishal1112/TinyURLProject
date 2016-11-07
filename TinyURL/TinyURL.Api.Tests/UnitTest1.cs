using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyURL.api;
using TinyURL.Api.Utility;
using TinyURL.DataStore.Services;
using TinyURL.Api.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Net;

namespace TinyURL.Api.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTinyURL()
        {
            TinyURLGenerator tGenerator = new TinyURLGenerator();
            TinyURLRepository tRepository = new TinyURLRepository();
            TinyURLController tController = new TinyURLController(tGenerator, tRepository);
            tController.Request = new HttpRequestMessage
            {

            };
            RequestCarrier req = new RequestCarrier()
            {
                PayLoad = "http://www.amazon.in/Clarks-Diggygrungejnr-Walnut-Leath-Leather/dp/B00C2LDGVA/ref=sr_1_87?s=shoes&ie=UTF8&qid=1478302742&sr=1-87&keywords=clarks+shoes+for+kids"
            };


            tController.Configuration = new HttpConfiguration();
            tController.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            tController.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "tinyURL" } });

            var response = tController.GetTinyUrl(req);
            Assert.AreEqual(true, ((System.Web.Http.Results.JsonResult<TinyURL.api.ResponseCarrier>)response).Content.Status);
        }
    }
}

