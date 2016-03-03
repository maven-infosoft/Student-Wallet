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
    public class BoardController : Controller
    {
        //
        // GET: /Board/
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
        public ActionResult Add(Board board, FormCollection fcol)
        {
            if (ModelState.IsValid)
            {
                string yr = fcol.Get("bName");
                string sp = "insertBoard";
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("Name", yr);
                para.Add("byWhom", 1);
                db.savedata(sp, para);
                return RedirectToAction("List");
            }

            return View(board);
        }
        public ActionResult List()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Admin", "Login", false);
            }
            else
            {
                List<Board> x = new List<Board>();
                string sp = "listBoard";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        x.Add(new Board
                        {
                            bID = Convert.ToInt32(dr["Board_Id"]),
                            bName = dr["Name"].ToString(),
                            CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                            CreatedByWhom = dr["CreatedByWhom"].ToString(),
                        });
                    }
                }

                return View(x);
            }
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.name = "Edit";
            if (Id != null)
            {
                Board b = new Board();
                string sp = "fetchBoard";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("id", Id);
                dt = db.getdata(sp, para);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        b.bID = Convert.ToInt32(dt.Rows[0]["Board_Id"]);
                        b.bName = dt.Rows[0]["Name"].ToString();
                    }
                }
                return View("Add", b);
            }
            return View("Add");
        }

        [HttpPost]
        public ActionResult Edit(Board board, FormCollection fcol, int id)
        {
            if (ModelState.IsValid)
            {
                string name = fcol.Get("bName");
                string sp = "updateboard";

                Dictionary<string, object> para = new Dictionary<string, object>();
                para.Add("name", name);
                para.Add("id", id);
                db.savedata(sp, para);
                return RedirectToAction("List");
            }

            return View(board);
        }
        public ActionResult Add_School_Map()
        {
            ViewBag.brd = f.fillboard();
            ViewBag.sch = f.fillschool();
            return View();
        }

        public ActionResult List_School_Map()
        {
            return View();
        }
	}
}