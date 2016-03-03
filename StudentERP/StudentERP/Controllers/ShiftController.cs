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
    public class ShiftController : Controller
    {
        //
        // GET: /Shift/
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
            string yr = fcol.Get("shiftName");
            string sp = "insertShift";
            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("Shift_Name", yr);
            para.Add("byWhom", 1);
            db.savedata(sp, para);
            
            return RedirectToAction("List");
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.name = "Edit";
            if (Id != null)
            {
                shift ay = new shift();
                string sp = "fetchShift";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.shiftId = Convert.ToInt32(dt.Rows[0]["Shift_Id"]);
                        ay.shiftName = dt.Rows[0]["Shift_Name"].ToString();
                    }
                }
                return View("Add", ay);
            }
            return View("Add");
        }

        [HttpPost]
        public ActionResult Edit(FormCollection fcol, int id)
        {
            string yr = fcol.Get("shiftName");
            string sp = "updateShift";

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
                List<shift> x = new List<shift>();
                string sp = "listShift";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new shift
                        {
                            shiftId = Convert.ToInt32(dr["Shift_Id"]),
                            shiftName = dr["Shift_Name"].ToString(),

                            CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                            createdByWhom = dr["TypeName"].ToString(),
                        });
                    }
                }
                return View(x);
            }
        }

        public ActionResult Add_Std_Div_Map()
        {
            ViewBag.standard = f.fillstandard();
            ViewBag.div = f.filldivision();
            ViewBag.shift = f.fillshift();
            ViewBag.yr = f.fillacademicyear();
            return View();
        }

        public ActionResult List_Std_Div_Map()
        {
            return View();
        }
	}
}