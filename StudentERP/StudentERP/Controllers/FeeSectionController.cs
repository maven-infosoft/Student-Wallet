﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using StudentERP.Models;

namespace StudentERP.Controllers
{
    public class FeeSectionController : Controller
    {
        DatabaseOperation db = new DatabaseOperation();
        //
        // GET: /FeeHeads/
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
            string yr = fcol.Get("fhName");
            string sp = "insertFeesSection";
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
                FeeHeads ay = new FeeHeads();
                string sp = "fetchFeesSection";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.fhID = Convert.ToInt32(dt.Rows[0]["Fees_Section_Id"]);
                        ay.fhName = dt.Rows[0]["Name"].ToString();
                    }
                }
                return View("Add", ay);
            }
            return View("Add");
        }

        [HttpPost]
        public ActionResult Edit(FormCollection fcol, int id)
        {
            string yr = fcol.Get("fhName");
            string sp = "updateFeesSection";

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
                List<FeeHeads> x = new List<FeeHeads>();
                string sp = "listFeesSection";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new FeeHeads
                        {
                            fhID = Convert.ToInt32(dr["Fees_Section_Id"]),
                            fhName = dr["Name"].ToString(),

                            CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                            createdByWhom = dr["TypeName"].ToString(),
                        });
                    }
                }
                return View(x);
            }
        }
	}
}