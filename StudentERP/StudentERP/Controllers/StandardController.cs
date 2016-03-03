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
    public class StandardController : Controller
    {
        //
        // GET: /Standard/
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
            string yr = fcol.Get("name");
            string los = fcol.Get("LevelOfStd");
            string sp = "insertStandard";
            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("Name", yr);
            para.Add("LevelOfstd", los);
            para.Add("byWhom", 1);
            db.savedata(sp, para);
            return RedirectToAction("List");
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.name = "Edit";
            if (Id != null)
            {
                Standard ay = new Standard();
                string sp = "fetchStandard";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.StandardId = Convert.ToInt32(dt.Rows[0]["StandardID"]);
                        ay.name = dt.Rows[0]["Name"].ToString();
                        ay.LevelOfStd = Convert.ToInt32(dt.Rows[0]["LevelOfstd"]);
                    }
                }
                return View("Add", ay);
            }
            return View("Add");
        }

        [HttpPost]
        public ActionResult Edit(FormCollection fcol, int id)
        {
            string yr = fcol.Get("name");
            string los = fcol.Get("LevelOfStd");
            string sp = "updateStandard";

            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("name", yr);
            para.Add("level", los);
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
                List<Standard> x = new List<Standard>();
                string sp = "listStandard";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new Standard
                        {
                            StandardId = Convert.ToInt32(dr["StandardID"]),
                            name = dr["Name"].ToString(),
                            LevelOfStd = Convert.ToInt32(dr["LevelOfstd"]),

                            CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                            createdByWhom = dr["TypeName"].ToString(),
                        });
                    }
                }
                return View(x);
            }
        }
        public ActionResult Add_Div_map()
        {
            ViewBag.standard = f.fillstandard();
            ViewBag.div = f.filldivision();
            ViewBag.yr = f.fillacademicyear();
            return View();
        }
        public ActionResult List_Div_map()
        {
            return View();
        }
	}
}