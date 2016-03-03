using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentERP.Controllers
{
    public class SubjectTeacherController : Controller
    {
        //
        // GET: /SubjectTeacher/
        FillDropdownlist f = new FillDropdownlist();
        public ActionResult Add()
        {
            ViewBag.sub = f.fillsubject();
            ViewBag.teacher = f.fillteacher();
            ViewBag.std = f.fillstandard();
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