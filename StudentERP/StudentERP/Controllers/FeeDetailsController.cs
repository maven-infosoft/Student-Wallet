using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentERP.Controllers
{
    public class FeeDetailsController : Controller
    {
        //
        // GET: /FeeDetails/
        FillDropdownlist f = new FillDropdownlist();
        public ActionResult Add()
        {
            ViewBag.std = f.fillstandard();
            ViewBag.shift = f.fillshift();
            ViewBag.fh = f.fillfeesection();
            ViewBag.yr = f.fillacademicyear();
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
	}
}