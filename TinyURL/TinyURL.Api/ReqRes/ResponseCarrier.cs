using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyURL.api
{
    public class ResponseCarrier
    {
        public ResponseCarrier()
        {
            Status = true;
            ErrorMessage = string.Empty;
            Additionaldata = string.Empty;
        }
        public bool Status { get; set; }

        public object PayLoad { get; set; }

        public string ErrorMessage { get; set; }

        public string Additionaldata { get; set; }
    }
}