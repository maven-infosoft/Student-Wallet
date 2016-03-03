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

    public class SchoolController : Controller
    {
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
            string yr = fcol.Get("schoolName");
            string sa = fcol.Get("schoolAddress");
            string sw = fcol.Get("schoolwebsite");
            decimal of =Convert.ToDecimal(fcol.Get("office"));
            decimal mn =Convert.ToDecimal(fcol.Get("mobNum"));

            string sp = "InsertSchool";
            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("Name", yr);
            para.Add("Address", sa);
            para.Add("WebsiteName", sw);
            para.Add("office_no", of);
            para.Add("mob_no", mn);
            para.Add("byWhom", 1);
            
            db.savedata(sp, para);
            return RedirectToAction("List");
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.name = "Edit";
            if (Id != null)
            {
                school ay = new school();
                string sp = "fetchSchool";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.schoolID = Convert.ToInt32(dt.Rows[0]["School_Id"]);
                        ay.schoolName = dt.Rows[0]["Name"].ToString();
                        ay.office = Convert.ToDecimal(dt.Rows[0]["office_no"]);
                        ay.mobNum=Convert.ToDecimal(dt.Rows[0]["mob_no"]);
                        ay.schoolwebsite=dt.Rows[0]["WebsiteName"].ToString();
                        ay.schoolAddress=dt.Rows[0]["Address"].ToString();
                    }
                }
                return View("Add", ay);
            }
            return View("Add");
        }

        [HttpPost]
        public ActionResult Edit(FormCollection fcol, int id)
        {
            string yr = fcol.Get("schoolName");
            string sa = fcol.Get("schoolAddress");
            string sw = fcol.Get("schoolwebsite");
            string of = fcol.Get("office");
            string mn = fcol.Get("mobNum");
            

            string sp = "updateSchool";

            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("name", yr);
            para.Add("address", sa);
            para.Add("Website", sw);
            para.Add("Off_no", of);
            para.Add("Mob_no", mn);
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
                List<school> x = new List<school>();
                string sp = "listSchool";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new school
                        {
                            schoolID = Convert.ToInt32(dr["school_ID"]),
                            schoolName = dr["Name"].ToString(),
                            office = Convert.ToDecimal(dr["office_no"]),
                            mobNum = Convert.ToDecimal(dr["mob_no"]),
                            schoolwebsite = dr["WebsiteName"].ToString(),
                            schoolAddress = dr["Address"].ToString(),
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