using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using StudentERP.Models;

namespace StudentERP.Controllers
{
    public class QualificationController : Controller
    {
        //
        // GET: /Qualification/
        DatabaseOperation db = new DatabaseOperation();
        public ActionResult Add()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Admin", "Login", false);
            }
            else
            {
                return View(ViewBag.name = "Add");
            }
        }

        [HttpPost]
        public ActionResult Add(FormCollection fcol)
        {
            string yr = fcol.Get("Name");
            string sp = "insertQualification";
            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("Name", yr);
            db.savedata(sp, para);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.name = "Edit";
            if (Id != null)
            {
                Qualification ay = new Qualification();
                string sp = "fetchQualification";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.QualificationId = Convert.ToInt32(dt.Rows[0]["QualificationId"]);
                        ay.Name = dt.Rows[0]["Name"].ToString();
                    }
                }
                return View("Add", ay);
            }
            return View("Add");
        }

        [HttpPost]
        public ActionResult Edit(FormCollection fcol, int id)
        {
            string yr = fcol.Get("Name");
            string sp = "updateQualification";

            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("name", yr);
            para.Add("id", id);
            db.savedata(sp, para);
            return RedirectToAction("List");
        }
      
         public ActionResult List()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Admin", "Login", false);
            }
            else
            {
                List<Qualification> x = new List<Qualification>();
                string sp = "listQualification";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new Qualification
                        {
                            QualificationId = Convert.ToInt32(dr["QualificationId"]),
                            Name = dr["name"].ToString(),

                        });
                    }
                }
                return View(x);
            }
        }
	}
}