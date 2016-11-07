using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ExceptionModel
    {
        public Exception MyException { get; set; }
        public string IpAddress { get; set; }
        public string RawURL { get; set; }
        public string Message { get; set; }
    }
}