using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyURL.DataStore;
using TinyURL.DataStore.Services;
using TinyURL.DataStore.Services.Implementation;
using Web.Models;

namespace Web.App_Start
{
    public class GlobalExceptionHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
            ILogger logger = new Logger();
            logger.LogError(new LogMessage()
            {
                Application = "Tiny Web",
                CreationDate = DateTime.Now,
                Exception = Convert.ToString(filterContext.Exception.InnerException),
                Summary = filterContext.Exception.Message,
                IP = filterContext.RequestContext.HttpContext.Request.UserHostAddress
            });
            filterContext.Result = new RedirectResult(@"/Error/ErrorOccurred?Msg=" + "OOPS! Something went wrong .Our support team is looking into it please re-try.");
        }
    }
}