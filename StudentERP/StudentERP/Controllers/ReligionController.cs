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
    public class ReligionController : Controller
    {
        //
        // GET: /Religion/
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
            string sp = "insertReligion";
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
                Religion ay = new Religion();
                string sp = "fetchReligion";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.ReligionID = Convert.ToInt32(dt.Rows[0]["ReligionID"]);
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
            string sp = "updateReligion";

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
                List<Religion> x = new List<Religion>();
                string sp = "listreligion";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new Religion
                        {
                            ReligionID = Convert.ToInt32(dr["ReligionID"]),
                            Name = dr["Name"].ToString(),

                        });
                    }
                }
                return View(x);
            }
        }
	}
}