using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using StudentERP.Models;

namespace StudentERP.Controllers
{

    public class AcademicYearController : Controller
    {
        DatabaseOperation db = new DatabaseOperation();
        FillDropdownlist f = new FillDropdownlist();
        //
        // GET: /AcademicYear/
        public ActionResult Add()
        {
            if (Session["user"]==null)
            {
                return RedirectToAction("Admin", "Login", false);
            }
            else { 
            return View(ViewBag.name = "Add");
            }
        }
        [HttpPost]
        public ActionResult Add(AcademicYear academicYear, FormCollection fcol)
        {
            if (ModelState.IsValid)
            {
                string yr = fcol.Get("Year");
                string sp = "insertAcademicYear";
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("Year", yr);
                para.Add("byWhom", 1);
                db.savedata(sp, para);
                return RedirectToAction("List");
            }

            return View(academicYear);
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.name = "Edit";
            if (Id != null)
            {
                AcademicYear ay = new AcademicYear();
                string sp = "fetchAcademicYear";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.academicId = Convert.ToInt32(dt.Rows[0]["AcademicID"]);
                        ay.Year = dt.Rows[0]["Year"].ToString();
                    }
                }
                return View("Add", ay);
            }
            return View("Add");
        }

        [HttpPost]
        public ActionResult Edit(AcademicYear academicYear, FormCollection fcol, int id)
        {
            if (ModelState.IsValid)
            {
                string yr = fcol.Get("Year");
                string sp = "updateAcademicYear";

                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("yr", yr);
                para.Add("id", id);
                db.savedata(sp, para);
                return RedirectToAction("List");
            }

            return View(academicYear);
        }
        public ActionResult List()
        {
            List<AcademicYear> ay = new List<AcademicYear>();
            string sp = "listAcademicYear";
            DataTable dt = new DataTable();
            Dictionary<string, object> para = new Dictionary<string, object>();
            dt = db.getdata(sp, para);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ay.Add(new AcademicYear
                     {
                         Year = dr["Year"].ToString(),
                         CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                         createdByWhom = dr["CreatedByWhom"].ToString(),
                         academicId = Convert.ToInt32(dr["AcademicID"])

                     });
                }
            }

            return View(ay);
        }


        public ActionResult Add_Std_Map()
        {
            ViewBag.stdlist = f.fillstandard();
           
            ViewBag.yr = f.fillacademicyear();
            ViewBag.monthlist = f.fillmonth();
           
            return View();
        }

        public ActionResult List_Std_Map()
        {
            return View();
        }

    }
}