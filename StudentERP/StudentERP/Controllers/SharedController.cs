using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentERP.Controllers
{
    public class SharedController : Controller
    {
        //
        // GET: /Shared/
        public ActionResult Error(string ErrorMessage)
        {
            ViewBag.ErrorMessage = ErrorMessage;
            return View();
        }

    }
}
