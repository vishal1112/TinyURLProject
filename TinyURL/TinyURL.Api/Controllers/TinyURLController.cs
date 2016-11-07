using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinyURL.api;
using TinyURL.Api.Utility;
using TinyURL.DataStore;
using TinyURL.DataStore.Services;

namespace TinyURL.Api.Controllers
{
    public class TinyURLController : ApiController
    {
        private ITinyURLGenerator _tinyUrlGenerator;
        private ITinyURLRepository _tinyURLRepository;

        public TinyURLController(ITinyURLGenerator tinyUrlGenerator, ITinyURLRepository tinuUrlRepository)
        {
            _tinyUrlGenerator = tinyUrlGenerator;
            _tinyURLRepository = tinuUrlRepository;
        }

        [HttpPost]
        public IHttpActionResult GetTinyUrl(RequestCarrier requestCarrier)
        {
            ResponseCarrier response;
            if (requestCarrier != null && requestCarrier.PayLoad != null)
            {
                string longUrl = requestCarrier.PayLoad.ToString();
                string shortenURL = _tinyUrlGenerator.GetTinyURL(longUrl);
                if (_tinyURLRepository.IsExist(shortenURL))
                {
                    shortenURL = _tinyUrlGenerator.GetTinyURL(longUrl);
                }
                if (!string.IsNullOrEmpty(shortenURL))
                {
                    URLMapping mapping = new URLMapping()
                    {
                        TinyUrl = shortenURL,
                        Url = longUrl
                    };
                    _tinyURLRepository.AddShortenedURLMapping(mapping);
                    response = new ResponseCarrier() { Status = true, PayLoad = shortenURL, ErrorMessage = string.Empty };
                }
                else
                {
                    response = new ResponseCarrier() { Status = false, PayLoad = null, ErrorMessage = "Request URL not provided." };
                }
            }
            else
            {
                response = new ResponseCarrier() { Status = false, PayLoad = null, ErrorMessage = "Request URL not provided." };
            }
            return Json(response);
        }

        [HttpPost]
        public IHttpActionResult RedirectUrl(RequestCarrier requestCarrier)
        {
            ResponseCarrier response;
            if (requestCarrier != null && requestCarrier.PayLoad != null)
            {
                string tinyUrl = requestCarrier.PayLoad.ToString();
                var urlMapping = _tinyURLRepository.GetURLMapping(tinyUrl);
                if (urlMapping != null && !string.IsNullOrEmpty(urlMapping.TinyUrl))
                {
                    response = new ResponseCarrier() { Status = true, PayLoad = urlMapping.Url, ErrorMessage = string.Empty };
                }
                else
                {
                    response = new ResponseCarrier() { Status = false, PayLoad = null, ErrorMessage = "Request URL not provided." };
                }
            }
            else
            {
                response = new ResponseCarrier() { Status = false, PayLoad = null, ErrorMessage = "Request URL not provided." };
            }
            return Json(response);
        }

    }
}
