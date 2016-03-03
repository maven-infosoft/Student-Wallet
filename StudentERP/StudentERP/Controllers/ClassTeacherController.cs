using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentERP.Controllers
{
    public class ClassTeacherController : Controller
    {
        //
        // GET: /ClassTeacher/
        FillDropdownlist f = new FillDropdownlist();
        public ActionResult Add()
        {
            ViewBag.standard = f.fillstandard();
            ViewBag.div = f.filldivision();
            ViewBag.yr = f.fillacademicyear();
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
	}
}