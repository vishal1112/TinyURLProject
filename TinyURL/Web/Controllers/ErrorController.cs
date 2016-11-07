using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string id)
        {
            ViewBag.ExceptionMessage = id;
            return View();
        }

        public ActionResult ErrorOccurred()
        {
            if (Request.QueryString != null)
            {
                var message = Request.QueryString["Msg"].ToString();
                ViewBag.ErrorMessage = message;
            }
            return View();
        }
    }
}