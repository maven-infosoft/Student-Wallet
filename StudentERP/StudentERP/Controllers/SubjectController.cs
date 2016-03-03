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
    public class SubjectController : Controller
    {
        //
        // GET: /Subject/
        FillDropdownlist f = new FillDropdownlist();
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
            string sp = "insertSubject";
            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("Name", yr);
            para.Add("byWhom", 1);
            db.savedata(sp, para);
            return RedirectToAction("List");
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.name = "Edit";
            if (Id != null)
            {
                Subject ay = new Subject();
                string sp = "fetchSubject";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.SubjectID = Convert.ToInt32(dt.Rows[0]["SubjectID"]);
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
            string sp = "updateSubject";

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
                List<Subject> x = new List<Subject>();
                string sp = "listSubject";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new Subject
                        {
                            SubjectID = Convert.ToInt32(dr["SubjectID"]),
                            Name = dr["Name"].ToString(),
                            CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                            createdByWhom = dr["TypeName"].ToString(),
                        });
                    }
                }
                return View(x);
            }
        }


        public ActionResult Add_Std_Map()
        {
            ViewBag.std = f.fillstandard();
            ViewBag.sub = f.fillsubject();
            ViewBag.yr = f.fillacademicyear();

            return View();
        }

        public ActionResult List_Std_Map()
        {
            return View();
        }
	}
}