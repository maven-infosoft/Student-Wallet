using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentERP.Controllers
{
    
    public class StateController : Controller
    {
        //
        // GET: /State/
        FillDropdownlist f = new FillDropdownlist();
        public ActionResult Add()
        {
            ViewBag.country = f.fillcountry();
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
	}
}