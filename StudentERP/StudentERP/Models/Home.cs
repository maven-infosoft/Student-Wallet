using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class exam_standard
    {
        [Display(Name = "Exam")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string exam { get; set; }


        [Display(Name = "Standard_Divison")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std_div { get; set; }
    }

    public class exam
    {
        [Display(Name = "Term")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string term { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }


        [Display(Name = "Label")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string lable { get; set; }
    }


    public class student_according_acadamic_year
    {
        [Display(Name = "Acadaic Year")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string ayear { get; set; }

        public List<System.Web.Mvc.SelectListItem> AcademicYears { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }

        public List<System.Web.Mvc.SelectListItem> Standards { get; set; }


        [Display(Name = "Division")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string div { get; set; }

        public List<System.Web.Mvc.SelectListItem> Divisions { get; set; }


        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string sname { get; set; }


        [Display(Name = "Roll no.")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter valid {0}.")]
        public string rollno { get; set; }
    }

    public class user
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter valid {0}.")]
        public string lgn { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Length of the password should be within 6 to 15.")]
        public string pwd { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string fname { get; set; }


        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string mname { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string lname { get; set; }


        [Display(Name = "Birthdate")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string dob { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter valid {0}.")]
        public string email { get; set; }
    }

    public class events
    {
        [Display(Name = "Type")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string typ { get; set; }


        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string titl { get; set; }


        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string sdate { get; set; }


        [Display(Name = "End Date")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string edate { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }


        [Display(Name = "Division")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string divi { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string descrp { get; set; }
    }

    public class notification
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string titl { get; set; }


        [Display(Name = "Type")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string typ { get; set; }


        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string sdate { get; set; }


        [Display(Name = "End Date")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string edate { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }


        [Display(Name = "Division")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string div { get; set; }


        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string sname { get; set; }


        [Display(Name = "Teacher Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string tname { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string descrp { get; set; }
    }

    public class assignment_worksheet
    {
        [Display(Name = "Assignment Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string aname { get; set; }


        [Display(Name = "Assignment Title")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string atitl { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string descrp { get; set; }


        [Display(Name = "Teacher Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string tname { get; set; }

        public List<System.Web.Mvc.SelectListItem> Teachers { get; set; }



        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }

        public List<System.Web.Mvc.SelectListItem> Standards { get; set; }
    }
}