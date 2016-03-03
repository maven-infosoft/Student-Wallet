using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentERP.Models;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace StudentERP.Controllers
{
    public class LoginController : Controller
    {
        DatabaseOperation db = new DatabaseOperation();
        //
        // GET: /Login/
        public ActionResult Admin()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home", false);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Login login, FormCollection col)
        {
            if(ModelState.IsValid)
            {
                string m = col.Get("email");
                string p = col.Get("pwd");

                string sp = "fetchLogin";

                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("em", m);
                para.Add("pwd", p);
                dt = db.getdata(sp, para);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        int type = Convert.ToInt32(dt.Rows[0]["empType_ID"]);
                        Session["user"] = dt.Rows[0]["empId"].ToString();

                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("pwd", "Invalid Username or Password.");
                        return View(login);
                    }
                }

                else
                {
                    return View(login);
                }
            }

            return View(login);
        }
    }
}