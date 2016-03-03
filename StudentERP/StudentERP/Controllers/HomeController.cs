using StudentERP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentERP.Controllers
{
    public class HomeController : Controller
    {
        DatabaseOperation Database = new DatabaseOperation();

        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Admin", "Login");

            var employee = new Employee();
            string storedProcedureName = "fetchEmployeeDetails";
            DataTable employeeTable = new DataTable();

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("empId", Session["user"].ToString());

            employeeTable = Database.getdata(storedProcedureName, Parameters);

            if (employeeTable.Rows.Count > 0)
            {
                foreach (DataRow row in employeeTable.Rows)
                {
                    employee.FirstName = row["FirstName"].ToString();
                    employee.LastName = row["LastName"].ToString();
                    employee.type = row["TypeName"].ToString();
                }
            }

            return View(employee);
        }
    }
}
//        string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

//        /* Fill the dropdowns with database values */

//        [NonAction]
//        public void fillStandard()
//        {
//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    con.Open();
//                    List<SelectListItem> standardlist = new List<SelectListItem>();
//                    SqlDataReader sdr = null;
//                    SqlCommand cmd = new SqlCommand("select StandardID,Name from StandardMaster", con);
//                    sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        standardlist.Add(new SelectListItem { Text = sdr["Name"].ToString(), Value = sdr["StandardID"].ToString() });

//                    }
//                    con.Close();
//                    ViewBag.standard = standardlist;
//                }
//                catch (Exception ex)
//                {
//                    RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
//        }

//        [NonAction]
//        public void filldiv()
//        {
//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    con.Open();
//                    List<SelectListItem> divlist = new List<SelectListItem>();
//                    SqlDataReader sdr = null;
//                    SqlCommand cmd = new SqlCommand("select DivisionID,Name from DivisionMaster", con);
//                    sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        divlist.Add(new SelectListItem { Text = sdr["Name"].ToString(), Value = sdr["DivisionID"].ToString() });
//                    }
//                    con.Close();
//                    ViewBag.div = divlist;
//                }

//                catch (Exception ex)
//                {
//                    RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
//        }

//        [NonAction]
//        public void fillaca_year()
//        {
//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    con.Open();
//                    List<SelectListItem> acalist = new List<SelectListItem>();
//                    SqlDataReader sdr = null;
//                    SqlCommand cmd = new SqlCommand("select AcademicID,Year from AcademicYearMaster", con);
//                    sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        acalist.Add(new SelectListItem { Text = sdr["Year"].ToString(), Value = sdr["AcademicID"].ToString() });

//                    }
//                    con.Close();
//                    ViewBag.yr = acalist;
//                }

//                catch (Exception ex)
//                {
//                    RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
//        }

//        [NonAction]
//        public void fillcountry()
//        {
//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    con.Open();
//                    List<SelectListItem> countrylist = new List<SelectListItem>();
//                    SqlDataReader sdr = null;
//                    SqlCommand cmd = new SqlCommand("select CountryID,Name from CountryMaster", con);
//                    sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        countrylist.Add(new SelectListItem { Text = sdr["Name"].ToString(), Value = sdr["CountryID"].ToString() });

//                    }
//                    con.Close();
//                    ViewBag.country = countrylist;
//                }

//                catch (Exception ex)
//                {
//                    RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
//        }

//        [NonAction]
//        public void fillstate()
//        {
//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    con.Open();
//                    List<SelectListItem> statelist = new List<SelectListItem>();
//                    SqlDataReader sdr = null;
//                    SqlCommand cmd = new SqlCommand("select StateID,Name from StateMaster", con);
//                    sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        statelist.Add(new SelectListItem { Text = sdr["Name"].ToString(), Value = sdr["StateID"].ToString() });

//                    }
//                    con.Close();
//                    ViewBag.state = statelist;
//                }

//                catch (Exception ex)
//                {
//                    RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
//        }

//        [NonAction]
//        public void fillfeeheads()
//        {
//            SqlConnection con = new SqlConnection(strcon);
//            con.Open();
//            List<SelectListItem> fhlist = new List<SelectListItem>();
//            SqlDataReader sdr = null;
//            SqlCommand cmd = new SqlCommand("select Fees_Head_Id,Name from Fees_Head", con);
//            sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                fhlist.Add(new SelectListItem { Text = sdr["Name"].ToString(), Value = sdr["Fees_Head_Id"].ToString() });
//            }
//            con.Close();
//            ViewBag.fh = fhlist;
//        }

//        [NonAction]
//        public int fetch_stddiv(int std, int div)
//        {
//            int sdid = 0;
//            SqlConnection con = new SqlConnection(strcon);
//            con.Open();
//            string query = "select StandardDivisionID from StandardDivisionMaster where StandardID=" + std + "and DivisionID=" + div;

//            SqlCommand cmd = new SqlCommand(query, con);
//            SqlDataReader sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                sdid = Convert.ToInt32(sdr["StandardDivisionID"]);
//            }
//            con.Close();
//            return sdid;
//        }

//        [NonAction]
//        public void fillshift()
//        {
//            SqlConnection con = new SqlConnection(strcon);
//            con.Open();
//            List<SelectListItem> sdslist = new List<SelectListItem>();
//            SqlDataReader sdr = null;
//            SqlCommand cmd = new SqlCommand("select Shift_Id,Shift_Name from Shift", con);
//            sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                sdslist.Add(new SelectListItem { Text = sdr["Shift_Name"].ToString(), Value = sdr["Shift_Id"].ToString() });
//            }
//            con.Close();
//            ViewBag.shift = sdslist;
//        }

//        [NonAction]
//        public void fillBoard()
//        {
//            SqlConnection con = new SqlConnection(strcon);
//            con.Open();
//            List<SelectListItem> boardlist = new List<SelectListItem>();
//            SqlDataReader sdr = null;
//            SqlCommand cmd = new SqlCommand("select Board_Id,Name from Board_Detail", con);
//            sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                boardlist.Add(new SelectListItem { Text = sdr["Name"].ToString(), Value = sdr["Board_Id"].ToString() });

//            }
//            con.Close();
//            ViewBag.brd = boardlist;
//        }

//        [NonAction]
//        public void fillSchool()
//        {
//            SqlConnection con = new SqlConnection(strcon);
//            con.Open();
//            List<SelectListItem> schlist = new List<SelectListItem>();
//            SqlDataReader sdr = null;
//            SqlCommand cmd = new SqlCommand("select School_Id,Name from SchoolDetail", con);
//            sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                schlist.Add(new SelectListItem { Text = sdr["Name"].ToString(), Value = sdr["School_Id"].ToString() });

//            }
//            con.Close();
//            ViewBag.sch = schlist;
//        }

//        public void fillEmpType()
//        {
//            SqlConnection con = new SqlConnection(strcon);
//            con.Open();
//            List<SelectListItem> EmptypeList = new List<SelectListItem>();
//            SqlDataReader sdr = null;
//            SqlCommand cmd = new SqlCommand("select empType_ID,TypeName from Employe_Type", con);
//            sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                EmptypeList.Add(new SelectListItem { Text = sdr["TypeName"].ToString(), Value = sdr["empType_ID"].ToString() });

//            }
//            con.Close();
//            ViewBag.emptype = EmptypeList;
//        }

//        [NonAction]
//        public void fillteacher()
//        {
//            SqlConnection con = new SqlConnection(strcon);
//            con.Open();
//            List<SelectListItem> teacherlist = new List<SelectListItem>();
//            SqlDataReader sdr = null;
//            SqlCommand cmd = new SqlCommand("select TeacherID,FirstName,LastName from TeacherLogin", con);
//            sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                teacherlist.Add(new SelectListItem { Text = sdr["FirstName"].ToString() + " " + sdr["LastName"].ToString(), Value = sdr["TeacherID"].ToString() });

//            }
//            con.Close();
//            ViewBag.teacher = teacherlist;
//        }

//        [NonAction]
//        public void fillsubject()
//        {
//            SqlConnection con = new SqlConnection(strcon);
//            con.Open();
//            List<SelectListItem> subjectlist = new List<SelectListItem>();
//            SqlDataReader sdr = null;
//            SqlCommand cmd = new SqlCommand("select SubjectID,Name from SubjectMaster", con);
//            sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                subjectlist.Add(new SelectListItem { Text = sdr["Name"].ToString(), Value = sdr["SubjectID"].ToString() });

//            }
//            con.Close();
//            ViewBag.sub = subjectlist;
//        }
//        /*------------------------------------------------------------------------------------*/

//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult About()
//        {
//            ViewBag.Message = "Your application description page.";

//            return View();
//        }

//        public ActionResult Contact()
//        {
//            ViewBag.Message = "Your contact page.";

//            return View();
//        }

//        public ActionResult Add_teacher()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_teacher(FormCollection fcol)
//        {
//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string pwd = fcol.Get("Password");
//                    string fname = fcol.Get("Firstname");
//                    string mname = fcol.Get("Middlename");
//                    string lname = fcol.Get("Lastname");
//                    string bdate = fcol.Get("Birthdate");
//                    string mail = fcol.Get("Email");
//                    string gen = (fcol.Get("Gender"));
//                    bool gender_get = true;

//                    if (gen.Equals("male"))
//                        gender_get = true;

//                    else
//                        gender_get = false;

//                    string cno = fcol.Get("ContactNo");
//                    string address = fcol.Get("Address");


//                    string qs = "insertTeacher";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("pass", pwd);
//                    cmd.Parameters.AddWithValue("fname", fname);
//                    cmd.Parameters.AddWithValue("mname", mname);
//                    cmd.Parameters.AddWithValue("lname", lname);
//                    cmd.Parameters.AddWithValue("birthdate", bdate);
//                    cmd.Parameters.AddWithValue("email", mail);
//                    cmd.Parameters.AddWithValue("gender", gender_get);
//                    cmd.Parameters.AddWithValue("contact_No", cno);
//                    cmd.Parameters.AddWithValue("address", address);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View();
//        }

//        public ActionResult Add_standard()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_standard(FormCollection fcol)
//        {
//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string fn = fcol.Get("name");
//                    int ln = Convert.ToInt32(fcol.Get("LevelOfStd"));

//                    string qs = "insertStandard";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("name", fn);
//                    cmd.Parameters.AddWithValue("level", ln);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View();
//        }

//        public ActionResult Add_division()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_division(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string divname = fcol.Get("Name");
//                    string qs = "insertDivison";
//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("div", divname);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View();
//        }

//        public ActionResult Add_subject()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_subject(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string sname = fcol.Get("Name");

//                    string qs = "insertSubject";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("name", sname);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View();
//        }

//        public ActionResult Add_qualification()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_qualification(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string quali = fcol.Get("Name");

//                    string qs = "insertQualification";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("name", quali);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View();
//        }

//        public ActionResult Add_occupation()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_occupation(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string ocu = fcol.Get("name");

//                    string qs = "insertOccupation";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("name", ocu);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View();
//        }

//        [HttpGet]
//        public ActionResult Add_acadamic_year()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_acadamic_year(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string yr = fcol.Get("Year");

//                    string qs = "insertAcaYear";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("year", yr);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMeesage = ex.Message });
//                }
//            }

//            return View();
//        }

//        [HttpGet]
//        public ActionResult Add_year_according_standard()
//        {
//            fillStandard();
//            fillaca_year();
//            List<SelectListItem> monthlist = new List<SelectListItem>();
//            monthlist.Add(new SelectListItem
//            {
//                Text = "January",
//                Value = "January"
//            });
//            monthlist.Add(new SelectListItem
//            {
//                Text = "February",
//                Value = "February"
//            });

//            monthlist.Add(new SelectListItem
//            {
//                Text = "March",
//                Value = "March"
//            });

//            monthlist.Add(new SelectListItem
//            {
//                Text = "April",
//                Value = "April"
//            });

//            monthlist.Add(new SelectListItem
//            {
//                Text = "May",
//                Value = "May"
//            });

//            monthlist.Add(new SelectListItem
//            {
//                Text = "June",
//                Value = "June"
//            });

//            monthlist.Add(new SelectListItem
//            {
//                Text = "July",
//                Value = "July"
//            });

//            monthlist.Add(new SelectListItem
//            {
//                Text = "August",
//                Value = "August"
//            });

//            monthlist.Add(new SelectListItem
//            {
//                Text = "September",
//                Value = "September"
//            });

//            monthlist.Add(new SelectListItem
//            {
//                Text = "October",
//                Value = "October"
//            });

//            monthlist.Add(new SelectListItem
//            {
//                Text = "November",
//                Value = "November"
//            });
//            monthlist.Add(new SelectListItem
//            {
//                Text = "December",
//                Value = "December"
//            });
//            ViewBag.monthList = monthlist;

//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_year_according_standard(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    var std = fcol["Standard"];
//                    var yr = fcol["AcadamicYear"];
//                    var sm = fcol["StartMonth"];
//                    var em = fcol["EndMonth"];

//                    string qs = "insertAcademicYrStd";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("aca", yr);
//                    cmd.Parameters.AddWithValue("std", std);
//                    cmd.Parameters.AddWithValue("smonth", sm);
//                    cmd.Parameters.AddWithValue("emonth", em);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return RedirectToAction("Index");
//        }

//        [HttpGet]
//        public ActionResult Add_subject_teacher()
//        {
//            fillteacher();
//            fillsubject();
//            fillStandard();
//            filldiv();
//            fillaca_year();
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_subject_teacher(FormCollection fcol)
//        {
//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    int std_ddl = Convert.ToInt32(fcol["Standard"]);
//                    int div_ddl = Convert.ToInt32(fcol["Division"]);
//                    var sub_ddl = fcol["Subject"];
//                    var yr_ddl = fcol["AcadamicYear"];
//                    var teacher_ddl = fcol["TeacherName"];
//                    int id = fetch_stddiv(std_ddl, div_ddl);

//                    string qs = "insertSubjectTeacher";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("stddiv", id);
//                    cmd.Parameters.AddWithValue("sub", sub_ddl);
//                    cmd.Parameters.AddWithValue("year", yr_ddl);
//                    cmd.Parameters.AddWithValue("teacher", teacher_ddl);
//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return RedirectToAction("Index");
//        }

        

//        [HttpGet]
//        public ActionResult Add_class_teacher()
//        {
//            fillteacher();
//            fillStandard();
//            filldiv();
//            fillaca_year();
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_class_teacher(FormCollection fcol)
//        {
//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    con.Open();

//                    int std_ddl = Convert.ToInt32(fcol["Standard"]);
//                    int div_ddl = Convert.ToInt32(fcol["Division"]);
//                    var teacher_ddl = fcol["TeacherName"];
//                    var yr_ddl = fcol["AcadamicYear"];

//                    int id = fetch_stddiv(std_ddl, div_ddl);

//                    string qs = "insertClassTeacher";

//                    SqlCommand cmd1 = new SqlCommand(qs, con);
//                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd1.Parameters.AddWithValue("teacher", teacher_ddl);
//                    cmd1.Parameters.AddWithValue("stddiv", id);
//                    cmd1.Parameters.AddWithValue("year", yr_ddl);
//                    cmd1.ExecuteNonQuery();
//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return RedirectToAction("Index");
//        }

        

//        public ActionResult Add_standard_wise_subject()
//        {
//            fillsubject();
//            fillStandard();
//            fillaca_year();
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_standard_wise_subject(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    var std_ddl = fcol["Standard"];
//                    var sub_ddl = fcol["Subject"];
//                    var yr_ddl = fcol["Year"];

//                    string qs = "insertstdvsub";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("sub", sub_ddl);
//                    cmd.Parameters.AddWithValue("std", std_ddl);
//                    cmd.Parameters.AddWithValue("yr", yr_ddl);
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return RedirectToAction("Index");
//        }

        

//        public ActionResult Add_standard_wise_division()
//        {
//            fillStandard();
//            filldiv();
//            fillaca_year();
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_standard_wise_division(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    var std = fcol["Standard"];
//                    var div = fcol["Division"];
//                    var year = fcol["Year"];

//                    string qs = "insertStdVDiv";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("std", std);
//                    cmd.Parameters.AddWithValue("div", div);
//                    cmd.Parameters.AddWithValue("year", year);
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return RedirectToAction("Index");
//        }

//        [HttpGet]
//        public ActionResult Add_exam_standrad()
//        {
//            List<SelectListItem> std_divlist = new List<SelectListItem>();
//            ViewBag.std_divlist = std_divlist;
//            List<SelectListItem> examlist = new List<SelectListItem>();
//            ViewBag.examlist = examlist;

//            return View();
//        }

//        [HttpGet]
//        public ActionResult Add_exam()
//        {
//            List<SelectListItem> termlist = new List<SelectListItem>();
//            ViewBag.termlist = termlist;
//            List<SelectListItem> stdlist = new List<SelectListItem>();
//            ViewBag.stdlist = stdlist;
//            return View();
//        }

//        [HttpGet]
//        public ActionResult Add_country()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_country(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string cn = fcol.Get("Name");

//                    string qs = "insertCountry";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("name", cn);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View();
//        }

        

//        [HttpGet]
//        public ActionResult Add_state()
//        {   
//            fillcountry();

//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_state(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    var cty = fcol["Country"];
//                    string st = fcol.Get("stat");

//                    string qs = "insertState";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("country", cty);
//                    cmd.Parameters.AddWithValue("state", st);
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return RedirectToAction("Index");
//        }

        

//        [HttpGet]
//        public ActionResult Add_city()
//        {
//            fillstate();
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_city(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    var st = fcol["State"];
//                    string ct = fcol.Get("cty");

//                    string qs = "insertCity";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("state", st);
//                    cmd.Parameters.AddWithValue("City", ct);
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return RedirectToAction("Index");
//        }

//        [HttpGet]
//        public ActionResult Add_student_according_acadamic_year()
//        {
//            List<SelectListItem> yearlist = new List<SelectListItem>();
//            ViewBag.yearlist = yearlist;
//            List<SelectListItem> std_divlist = new List<SelectListItem>();
//            ViewBag.std_divlist = std_divlist;
//            return View();
//        }

//        public ActionResult Add_user()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_user(user user)
//        {
//            return View();
//        }

//        public ActionResult Add_religon()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_religon(FormCollection fcol)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string rname = fcol.Get("Name");

//                    string qs = "insertReligion";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("name", rname);

//                    cmd.ExecuteNonQuery();

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View();
//        }

//        public ActionResult Add_events()
//        {
//            List<SelectListItem> typelist = new List<SelectListItem>();
//            ViewBag.typelist = typelist;

//            List<SelectListItem> stdlist = new List<SelectListItem>();
//            ViewBag.stdlist = stdlist;

//            List<SelectListItem> divlist = new List<SelectListItem>();
//            ViewBag.divlist = divlist;
//            return View();
//        }

//        public ActionResult Add_notification()
//        {
//            List<SelectListItem> typelist = new List<SelectListItem>();
//            ViewBag.typelist = typelist;

//            List<SelectListItem> stdlist = new List<SelectListItem>();
//            ViewBag.stdlist = stdlist;

//            List<SelectListItem> divlist = new List<SelectListItem>();
//            ViewBag.divlist = divlist;

//            return View();
//        }

//        public ActionResult Add_assignment_and_worksheet()
//        {
//            List<SelectListItem> stdlist = new List<SelectListItem>();
//            ViewBag.stdlist = stdlist;

//            List<SelectListItem> teacherlist = new List<SelectListItem>();
//            ViewBag.teacherlist = teacherlist;
//            return View();
//        }

//        public ActionResult Admin_login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Admin_login(login l, FormCollection fc)
//        {
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string em = fc.Get("email");
//                    string pwd = fc.Get("pwd");

//                    con.Open();
//                    string q = "Admin_login";
//                    SqlCommand cmd = new SqlCommand(q, con);
//                    cmd.Parameters.AddWithValue("em", em);
//                    cmd.Parameters.AddWithValue("pwd", pwd);
//                    cmd.Connection = con;
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
//                    DataTable dt = new DataTable();
//                    adpt.Fill(dt);
//                    if (dt.Rows.Count > 0)
//                    {
//                        Session["user"] = dt.Rows[0]["TeacherId"].ToString();
//                        return RedirectToAction("Index", "Home");
//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View();
//        }

//        public ActionResult Change_pwd()
//        {
//            return View();
//        }

//        public ActionResult Forgot_pwd()
//        {
//            return View();
//        }

//        public ActionResult add_empType()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult add_empType(FormCollection fcol)
//        {
//            SqlConnection con = new SqlConnection(strcon);

//            string empname = fcol["emptype_name"];

//            string qs = "insertEmpType";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("name", empname);

//            cmd.ExecuteNonQuery();

//            return RedirectToAction("Index");
//        }
//        public ActionResult Add_shift()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Add_shift(FormCollection fcol)
//        {
//            SqlConnection con = new SqlConnection(strcon);

//            string shiftname = fcol.Get("shiftName");

//            string qs = "insertShift";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("shift", shiftname);
//            cmd.ExecuteNonQuery();

//            return View();
//        }
//        public ActionResult Add_schoolDetails()
//        {

//            return View();
//        }
//        [HttpPost]
//        public ActionResult Add_schoolDetails(FormCollection fcol)
//        {
//            SqlConnection con = new SqlConnection(strcon);

//            string name = fcol.Get("schoolName");
//            string address = fcol.Get("schoolAddress");
//            string website = fcol.Get("schoolwebsite");
//            decimal officeno = Convert.ToDecimal(fcol.Get("office"));
//            decimal cno = Convert.ToDecimal(fcol.Get("mobNum"));

//            string qs = "insertSchool";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("name", name);
//            cmd.Parameters.AddWithValue("site", address);
//            cmd.Parameters.AddWithValue("add", website);
//            cmd.Parameters.AddWithValue("off_no", officeno);
//            cmd.Parameters.AddWithValue("mob_no", cno);

//            cmd.ExecuteNonQuery();

//            return RedirectToAction("Index");
//        }
//        public ActionResult Add_board()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add_board(FormCollection fcol)
//        {
//            SqlConnection con = new SqlConnection(strcon);

//            string name = fcol.Get("bName");

//            string qs = "insertBoard";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("name", name);

//            cmd.ExecuteNonQuery();

//            return RedirectToAction("Index");
//        }
//        public ActionResult Add_board_wies_school()
//        {
//            fillBoard();
//            fillSchool();
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Add_board_wies_school(FormCollection fcol)
//        {
//            SqlConnection con = new SqlConnection(strcon);

//            var sch_ddl = fcol["School"];
//            var brd_ddl = fcol["Board"];


//            string qs = "insertBoardAccSchool";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("sch", sch_ddl);
//            cmd.Parameters.AddWithValue("board", brd_ddl);

//            cmd.ExecuteNonQuery();

//            return RedirectToAction("Index");
//        }
//        public ActionResult Add_Std_div_shift()
//        {
//            fillStandard();
//            filldiv();
//            fillshift();
//            fillaca_year();
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Add_Std_div_shift(FormCollection fcol)
//        {
//            SqlConnection con = new SqlConnection(strcon);

//            int std_ddl = Convert.ToInt32(fcol["Standard"]);
//            int div_ddl = Convert.ToInt32(fcol["Division"]);
//            var sft_ddl = fcol["Shift"];

//            int yr = Convert.ToInt32(fcol["AcadamicYear"]);
//            string st = fcol.Get("stime");
//            string et = fcol.Get("etime");

//            int id = fetch_stddiv(std_ddl, div_ddl);

//            string qs = "insertStd_Div_sift";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("stddivid", id);
//            cmd.Parameters.AddWithValue("shiftid", sft_ddl);
//            cmd.Parameters.AddWithValue("year", yr);
//            cmd.Parameters.AddWithValue("s_time", st);
//            cmd.Parameters.AddWithValue("e_time", et);

//            cmd.ExecuteNonQuery();

//            return RedirectToAction("Index");
//        }
//        public ActionResult Add_feeHeads()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Add_feeHeads(FormCollection fcol)
//        {
//            SqlConnection con = new SqlConnection(strcon);

//            string name = fcol.Get("fhName");

//            string qs = "insertFeesHead";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("name", name);

//            cmd.ExecuteNonQuery();

//            return View();
//        }
//        public ActionResult Fees_according_standard_and_shift()
//        {
//            fillStandard();
//            fillshift();
//            fillfeeheads();
//            fillaca_year();
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Fees_according_standard_and_shift(FormCollection fcol)
//        {
//            SqlConnection con = new SqlConnection(strcon);
//            var std_ddl = fcol["Standard"];
//            var shft_ddl = fcol["Shift"];
//            var fee_ddl = fcol["FeesHead"];
//            var aca_ddl = fcol["Year"];
//            decimal amt = Convert.ToDecimal(fcol.Get("fees"));

//            string qs = "insertFees_std_shift";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("std", std_ddl);
//            cmd.Parameters.AddWithValue("shift", shft_ddl);
//            cmd.Parameters.AddWithValue("fees_Head", fee_ddl);
//            cmd.Parameters.AddWithValue("yr", aca_ddl);
//            cmd.Parameters.AddWithValue("amount", amt);
//            cmd.ExecuteNonQuery();

//            return View("Index");
//        }

//        //----------------------View Pages-------------------------------------

//        public ActionResult List_Std()
//        {
//            List<Standard> std = new List<Standard>();

//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listStd";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        std.Add(new Standard { StandardId = Convert.ToInt32(sdr["StandardID"]), name = sdr["Name"].ToString(), LevelOfStd = Convert.ToInt32(sdr["LevelOfstd"]) });
//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View(std);
//        }

//        public ActionResult List_Div()
//        {
//            List<division> div = new List<division>();

//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listDiv";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        div.Add(new division
//                        {
//                            DivisonID = Convert.ToInt32(sdr["DivisionID"]),
//                            Name = sdr["Name"].ToString()
//                        });
//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View(div);
//        }

//        public ActionResult list_Sub()
//        {
//            List<subject> sub = new List<subject>();

//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listsub";
//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        sub.Add(new subject
//                        {
//                            SubjectID = Convert.ToInt32(sdr["SubjectID"]),
//                            Name = sdr["Name"].ToString()
//                        });
//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View(sub);
//        }

//        public ActionResult List_classTeacher()
//        {
//            List<class_teacher> c_teacher = new List<class_teacher>();
            
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listClassTeacher";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        c_teacher.Add(new class_teacher
//                        {
//                            ClassTeacherID = Convert.ToInt32(sdr["ClassTeacherID"]),
//                            tname = sdr["FirstName"].ToString() + " " + sdr["LastName"].ToString(),
//                            acadyear = sdr["Year"].ToString(),
//                            std = sdr["Name"].ToString(),
//                            div = sdr["divname"].ToString()
//                        });

//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View(c_teacher);
//        }

//        public ActionResult List_SubTeacher()
//        {
//            List<subject_teacher> s_teacher = new List<subject_teacher>();

//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listSubTeacher";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        s_teacher.Add(new subject_teacher
//                        {
//                            subjectteacherId = Convert.ToInt32(sdr["SubjectTeacherId"]),
//                            tname = sdr["FirstName"].ToString() + " " + sdr["LastName"].ToString(),
//                            acadyear = sdr["Year"].ToString(),
//                            std = sdr["Name"].ToString(),
//                            div = sdr["divname"].ToString(),
//                            sub = sdr["SubName"].ToString()

//                        });
//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View(s_teacher);
//        }

//        public ActionResult List_Religion()
//        {

//            List<religion> rel = new List<religion>();
            
//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listreligion";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        rel.Add(new religion
//                        {
//                            ReligionID = Convert.ToInt32(sdr["ReligionID"]),
//                            Name = sdr["Name"].ToString()
//                        });

//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View(rel);
//        }

//        public ActionResult List_qualification()
//        {
//            List<qualification> qul = new List<qualification>();

//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listQualification";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        qul.Add(new qualification
//                        {
//                            QualificationId = Convert.ToInt32(sdr["QualificationId"]),
//                            Name = sdr["Name"].ToString()
//                        });
//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View(qul);
//        }

//        public ActionResult List_Occupation()
//        {
//            List<occupation> oac = new List<occupation>();

//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listOccupation";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        oac.Add(new occupation
//                        {
//                            OccupationId = Convert.ToInt32(sdr["OccupationId"]),
//                            name = sdr["name"].ToString()
//                        });

//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View(oac);
//        }

//        public ActionResult ListStandardDivison()
//        {
//            List<standard_wies_division> stdiv = new List<standard_wies_division>();

//            using(SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listStandardDivison";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        stdiv.Add(new standard_wies_division
//                        {
//                            standivid = Convert.ToInt32(sdr["StandardDivisionID"]),
//                            std = sdr["Name"].ToString(),
//                            divi = sdr["DivName"].ToString(),
//                            Year = sdr["Year"].ToString()
//                        });
//                    }

//                    con.Close();
//                }

//                catch(Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View(stdiv);
//        }

//        public ActionResult listStandardSubject()
//        {
//            List<standard_wies_subject> stdsub = new List<standard_wies_subject>();

//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listStandardsubject";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        stdsub.Add(new standard_wies_subject
//                        {
//                            standardvisesubject = Convert.ToInt32(sdr["StandardWiseSubjectID"]),
//                            std = sdr["Name"].ToString(),
//                            sub = sdr["subname"].ToString(),
//                            aca = sdr["Year"].ToString()
//                        });
//                    }

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View(stdsub);
//        }

//        public ActionResult ListyearAccordingTOStandard()
//        {
//            List<year_according_standard> stdyear = new List<year_according_standard>();

//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listYearAccStd";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        stdyear.Add(new year_according_standard
//                        {
//                            yearStandardId = Convert.ToInt32(sdr["Academic_year_standardId"]),
//                            astd = sdr["Name"].ToString(),
//                            smonth = sdr["Start_month"].ToString(),
//                            emonth = sdr["End_Month"].ToString(),
//                            ayear = sdr["Year"].ToString()
//                        });
//                    }

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View(stdyear);
//        }

//        public ActionResult List_Teacher()
//        {
//            List<teacher> listTeach = new List<teacher>();

//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listTeacher";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        listTeach.Add(new teacher
//                        {
//                            TecherId = Convert.ToInt32(sdr["TeacherId"]),
//                            FirstName = sdr["FirstName"].ToString(),
//                            MiddleName = sdr["MiddleName"].ToString(),
//                            LastName = sdr["LastName"].ToString(),
//                            Birthdate = Convert.ToDateTime(sdr["Birthdate"]),
//                            Email = sdr["Email"].ToString(),
//                            ContactNo = Convert.ToDecimal(sdr["ContactNo"]),
//                            Address = sdr["Address"].ToString(),
//                        });
//                    }

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }
            
//            return View(listTeach);
//        }

//        public ActionResult listCountry()
//        {
//            List<country> listcty = new List<country>();

//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listCountry";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        listcty.Add(new country
//                        {
//                            CountryId = Convert.ToInt32(sdr["CountryId"]),
//                            Name = sdr["Name"].ToString(),

//                        });
//                    }

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View(listcty);
//        }

//        public ActionResult listState()
//        {
//            List<state> liststate = new List<state>();

//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listState";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        liststate.Add(new state
//                        {
//                            stat = sdr["Name"].ToString(),

//                        });
//                    }

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View(liststate);
//        }

//        public ActionResult listCity()
//        {
//            List<city> listcity = new List<city>();

//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "List_city";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        listcity.Add(new city
//                        {
//                            cty = sdr["Name"].ToString(),

//                        });
//                    }

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View(listcity);
//        }

//        public ActionResult list_acadamicYear()
//        {
//            List<acadamic_year> listyr = new List<acadamic_year>();

//            using (SqlConnection con = new SqlConnection(strcon))
//            {
//                try
//                {
//                    string qs = "listYear";

//                    con.Open();
//                    SqlCommand cmd = new SqlCommand(qs, con);
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.ExecuteNonQuery();
//                    SqlDataReader sdr = cmd.ExecuteReader();
//                    while (sdr.Read())
//                    {
//                        listyr.Add(new acadamic_year
//                        {
//                            academicId = Convert.ToInt32(sdr["AcademicID"]),
//                            Year = sdr["Year"].ToString(),
//                            //isact=Convert.ToBoolean(sdr["IsActiveYear"])
//                        });
//                    }

//                    con.Close();
//                }

//                catch (Exception ex)
//                {
//                    return RedirectToAction("Error", "Shared", new { ErrorMessage = ex.Message });
//                }
//            }

//            return View(listyr);
//        }

//        public ActionResult list_sift()
//        {
//            List<shift> listShift = new List<shift>();
//            SqlConnection con = new SqlConnection(strcon);
//            string qs = "listShift";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.ExecuteNonQuery();
//            SqlDataReader sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                listShift.Add(new shift
//                {
//                    shiftId = Convert.ToInt32(sdr["Shift_Id"]),
//                    shiftName = sdr["Shift_Name"].ToString(),
//                });
//            }
//            return View(listShift);
//        }
//        public ActionResult list_EmpType()
//        {
//            List<emptype> listEtype = new List<emptype>();
//            SqlConnection con = new SqlConnection(strcon);
//            string qs = "listEmpType";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.ExecuteNonQuery();
//            SqlDataReader sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                listEtype.Add(new emptype
//                {
//                    empId = Convert.ToInt32(sdr["empType_ID"]),
//                    emptype_name = sdr["TypeName"].ToString(),
//                });
//            }
//            return View(listEtype);
//        }
//        public ActionResult list_board()
//        {
//            List<board> listboard = new List<board>();
//            SqlConnection con = new SqlConnection(strcon);
//            string qs = "listBoard";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.ExecuteNonQuery();
//            SqlDataReader sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                listboard.Add(new board
//                {
//                    bID = Convert.ToInt32(sdr["Board_Id"]),
//                    bName = sdr["Name"].ToString(),
//                });
//            }
//            return View(listboard);
//        }
//        public ActionResult list_fee_heads()
//        {
//            List<feeHeads> listfh = new List<feeHeads>();
//            SqlConnection con = new SqlConnection(strcon);
//            string qs = "listFeesHead";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.ExecuteNonQuery();
//            SqlDataReader sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                listfh.Add(new feeHeads
//                {
//                    fhID = Convert.ToInt32(sdr["Fees_Head_Id"]),
//                    fhName = sdr["Name"].ToString(),
//                });
//            }
//            return View(listfh);
//        }
//        public ActionResult list_schoolDetail()
//        {
//            List<school> schdetail = new List<school>();
//            SqlConnection con = new SqlConnection(strcon);
//            string qs = "listSchool";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.ExecuteNonQuery();
//            SqlDataReader sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                schdetail.Add(new school
//                {
//                    schoolID = Convert.ToInt32(sdr["School_Id"]),
//                    schoolName = sdr["Name"].ToString(),
//                    schoolAddress = sdr["Address"].ToString(),
//                    schoolwebsite = sdr["WebsiteName"].ToString(),
//                    office = Convert.ToDecimal(sdr["office_no"]),
//                    mobNum = Convert.ToDecimal(sdr["mob_no"]),
//                });
//            }
//            return View(schdetail);
//        }
//        public ActionResult list_board_wise_school()
//        {
//            List<board_School> listboardschool = new List<board_School>();
//            SqlConnection con = new SqlConnection(strcon);
//            string qs = "listSchoolBoard";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.ExecuteNonQuery();
//            SqlDataReader sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                listboardschool.Add(new board_School
//                {
//                    bname = sdr["Name"].ToString(),
//                    sname = sdr["schoolname"].ToString(),
//                });
//            }
//            return View(listboardschool);
//        }
//        public ActionResult list_std_div_shift()
//        {
//            List<std_div_shift> listsds = new List<std_div_shift>();
//            SqlConnection con = new SqlConnection(strcon);
//            string qs = "listStd_div_Shift";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.ExecuteNonQuery();
//            SqlDataReader sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                listsds.Add(new std_div_shift
//                {
//                    ayear = sdr["Year"].ToString(),
//                    shft = sdr["Shift_Name"].ToString(),
//                    std = sdr["stdName"].ToString(),
//                    div = sdr["Name"].ToString(),
//                    stime = sdr["StartTime"].ToString(),
//                    etime = sdr["endTime"].ToString(),
//                });
//            }
//            return View(listsds);
//        }
//        public ActionResult list_fee_std_shift_ay()
//        {
//            List<fees_acc_std_shift> list = new List<fees_acc_std_shift>();
//            SqlConnection con = new SqlConnection(strcon);
//            string qs = "listFees_std_shift";

//            con.Open();
//            SqlCommand cmd = new SqlCommand(qs, con);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.ExecuteNonQuery();
//            SqlDataReader sdr = cmd.ExecuteReader();
//            while (sdr.Read())
//            {
//                list.Add(new fees_acc_std_shift
//                {
//                    ay = sdr["Year"].ToString(),
//                    shft = sdr["Shift_Name"].ToString(),
//                    std = sdr["Name"].ToString(),
//                    feehd = sdr["HeadName"].ToString(),
//                    feeamt = Convert.ToDecimal(sdr["Amount"]),
//                });
//            }
//            return View(list);
//        }
//    }
//}