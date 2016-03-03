using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using StudentERP.Models;
using System.Web.Mvc;

namespace StudentERP
{

    public class FillDropdownlist
    {
        DatabaseOperation db = new DatabaseOperation();
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillstandard()
        {
            List<SelectListItem> standardlist = new List<SelectListItem>();
            try
            {
                string sp = "ddlStandard";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        standardlist.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["StandardID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return standardlist;
        }

        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> filldivision()
        {
            List<SelectListItem> divlist = new List<SelectListItem>();
            //try
            //{
                string sp = "ddlDivison";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        divlist.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["DivisionID"].ToString() });
                    }
                }
            //}
            //catch (Exception ex)
            //{
              
            //}
            return divlist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillacademicyear()
        {
            List<SelectListItem> aylist = new List<SelectListItem>();
            try
            {
                string sp = "ddlAcademicYear";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    { 
                    aylist.Add(new SelectListItem { Text = dr["Year"].ToString(), Value = dr["AcademicID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return aylist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillcountry()
        {
            List<SelectListItem> ctylist = new List<SelectListItem>();
            try
            {
                string sp = "ddlCountry";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ctylist.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["CountryID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return ctylist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillstate()
        {
            List<SelectListItem> stlist = new List<SelectListItem>();
            try
            {
                string sp = "ddlState";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        stlist.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["StateID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return stlist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillfeesection()
        {
            List<SelectListItem> fslist = new List<SelectListItem>();
            try
            {
                string sp = "ddlFeesSection";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        fslist.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["Fees_Section_Id"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return fslist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillshift()
        {
            List<SelectListItem> shiftlist = new List<SelectListItem>();
            try
            {
                string sp = "ddlShift";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        shiftlist.Add(new SelectListItem { Text = dr["Shift_Name"].ToString(), Value = dr["Shift_Id"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return shiftlist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillboard()
        {
            List<SelectListItem> brdlist = new List<SelectListItem>();
            try
            {
                string sp = "ddlBoard";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        brdlist.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["Board_Id"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return brdlist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillschool()
        {
            List<SelectListItem> schlist = new List<SelectListItem>();
            try
            {
                string sp = "ddlSchool";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        schlist.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["School_Id"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return schlist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillemptype()
        {
            List<SelectListItem> etlist = new List<SelectListItem>();
            try
            {
                string sp = "ddlEmployeeType";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        etlist.Add(new SelectListItem { Text = dr["TypeName"].ToString(), Value = dr["empType_ID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return etlist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillteacher()
        {
            List<SelectListItem> teacherlist = new List<SelectListItem>();
            try
            {
                string sp = "ddlEmployee";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        teacherlist.Add(new SelectListItem { Text = dr["FirstName"].ToString() + ' ' + dr["LastName"], Value = dt.Rows[0]["empId"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return teacherlist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillsubject()
        {
            List<SelectListItem> sublist = new List<SelectListItem>();
            try
            {
                string sp = "ddlSubject";
                DataTable dt = new DataTable();
                Dictionary<string, object> para = new Dictionary<string, object>();
                dt = db.getdata(sp, para);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        sublist.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["SubjectID"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return sublist;
        }
        //------------------------------------------------------------------------------------------------------------------
        public List<SelectListItem> fillmonth()
        {
            List<SelectListItem> mthlist = new List<SelectListItem>();
            try
            {
                mthlist.Add(new SelectListItem
                {
                    Text = "January",
                    Value = "January"
                });
                mthlist.Add(new SelectListItem
                {
                    Text = "February",
                    Value = "February"
                });

                mthlist.Add(new SelectListItem
                {
                    Text = "March",
                    Value = "March"
                });

                mthlist.Add(new SelectListItem
                {
                    Text = "April",
                    Value = "April"
                });

                mthlist.Add(new SelectListItem
                {
                    Text = "May",
                    Value = "May"
                });

                mthlist.Add(new SelectListItem
                {
                    Text = "June",
                    Value = "June"
                });

                mthlist.Add(new SelectListItem
                {
                    Text = "July",
                    Value = "July"
                });

                mthlist.Add(new SelectListItem
                {
                    Text = "August",
                    Value = "August"
                });

                mthlist.Add(new SelectListItem
                {
                    Text = "September",
                    Value = "September"
                });

                mthlist.Add(new SelectListItem
                {
                    Text = "October",
                    Value = "October"
                });

                mthlist.Add(new SelectListItem
                {
                    Text = "November",
                    Value = "November"
                });
                mthlist.Add(new SelectListItem
                {
                    Text = "December",
                    Value = "December"
                });
            }
            catch (Exception ex)
            {

            }
            return mthlist;
        }
    }
}