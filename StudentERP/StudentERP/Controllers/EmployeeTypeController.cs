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
    public class EmployeeTypeController : Controller
    {
        DatabaseOperation db = new DatabaseOperation();
        //
        // GET: /EmployeeType/
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
        public ActionResult Add(EmployeeType employeeType, FormCollection fcol)
        {
            if(ModelState.IsValid)
            {
                string yr = fcol.Get("emptype_name");
                string sp = "insertEmployeeType";
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("TypeName", yr);
                para.Add("byWhom", 1);
                db.savedata(sp, para);
                return RedirectToAction("List");
            }

            return View(employeeType);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.name = "Edit";
            if (Id != null)
            {
                EmployeeType ay = new EmployeeType();
                string sp = "fetchEmployeeType";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ay.typeId = Convert.ToInt32(dt.Rows[0]["empType_ID"]);
                        ay.emptype_name = dt.Rows[0]["TypeName"].ToString();
                    }
                }
                return View("Add", ay);
            }
            return View("Add");
        }

        [HttpPost]
        public ActionResult Edit(EmployeeType employeeType, FormCollection fcol, int id)
        {
            if(ModelState.IsValid)
            {
                string yr = fcol.Get("emptype_name");
                string sp = "updateEmplyeeType";

                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("name", yr);
                para.Add("id", id);
                db.savedata(sp, para);
                return RedirectToAction("List");
            }

            return View(employeeType);
        }

        public ActionResult List()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Admin", "Login", false);
            }
            else
            {
                List<EmployeeType> x = new List<EmployeeType>();
                string sp = "listEmployeeType";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new EmployeeType
                        {
                            emptype_name = dr["TypeName"].ToString(),
                            typeId = Convert.ToInt32(dr["empType_ID"]),
                            CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                            createdByWhom = dr["Name"].ToString(),
                        });
                    }
                }
                return View(x);
            }
        }
	}
}