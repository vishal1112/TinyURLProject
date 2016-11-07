using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Web.ReqRes
{
    public class WebApiClient : HttpClient
    {
        public string WebAPIHostURL;
        public WebApiClient()
        {
            WebAPIHostURL = ConfigurationManager.AppSettings["WebApiDomain"].ToString();
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> PostAsyncMyTinyURL(object data)
        {
            return await this.PostAsJsonAsync(WebAPIHostURL + "RedirectUrl", data);
        }
    }
}