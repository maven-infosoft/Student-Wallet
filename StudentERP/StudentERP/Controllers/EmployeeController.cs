using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentERP.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        FillDropdownlist f = new FillDropdownlist();
        public ActionResult Add()
        {
            ViewBag.emptype = f.fillemptype();
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
	}
}