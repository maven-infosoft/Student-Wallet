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
    public class CountryController : Controller
    {
        //
        // GET: /Country/
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
        public ActionResult Add(Country country, FormCollection fcol)
        {
            if (ModelState.IsValid)
            {
                string yr = fcol.Get("Name");
                string sp = "insertCountry";
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("Name", yr);
                para.Add("byWhom", 1);
                db.savedata(sp, para);
                return RedirectToAction("List");
            }

            return View(country);
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.name = "Edit";
            if (Id != null)
            {
                Country ay = new Country();
                string sp = "fetchCountry";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.CountryId = Convert.ToInt32(dt.Rows[0]["CountryID"]);
                        ay.Name = dt.Rows[0]["Name"].ToString();
                    }
                }
                return View("Add", ay);
            }
            return View("Add");
        }

        [HttpPost]
        public ActionResult Edit(Country country, FormCollection fcol, int id)
        {
            if (ModelState.IsValid)
            {
                string yr = fcol.Get("Name");
                string sp = "updateCountry";

                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("name", yr);
                para.Add("id", id);
                db.savedata(sp, para);
                return RedirectToAction("List");
            }

            return View(country);
        }
      
   
        public ActionResult List()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Admin", "Login", false);
            }
            else
            {
                List<Country> x = new List<Country>();
                string sp = "listCountry";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new Country
                        {
                            Name = dr["Name"].ToString(),
                            CountryId = Convert.ToInt32(dr["CountryID"]),
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