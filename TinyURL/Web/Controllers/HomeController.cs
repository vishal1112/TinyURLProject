using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.ReqRes;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        WebApiClient wClient;
        public HomeController()
        {
            wClient = new WebApiClient();
        }

        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> MyTinyUrl(string id)
        {
            RequestCarrier req = new RequestCarrier()
            {
                PayLoad = id
            };
            WebApiClient wClient = new WebApiClient();
            HttpResponseMessage responseMessage = await wClient.PostAsyncMyTinyURL(req);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<ResponseCarrier>(responseData);
                if (data != null && data.PayLoad != null)
                {
                    string redirectUrl = data.PayLoad.ToString();
                    return Redirect(redirectUrl);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}