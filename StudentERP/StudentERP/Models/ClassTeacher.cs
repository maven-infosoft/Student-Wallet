using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class ClassTeacher
    {
        public int ClassTeacherID { get; set; }


        [Display(Name = "Teacher Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string tname { get; set; }

        public List<System.Web.Mvc.SelectListItem> TeacherName { get; set; }


        [Display(Name = "Acadamic Year")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [MinLength(4, ErrorMessage = "Please enter valid {0}.")]
        public string acadyear { get; set; }

        public List<System.Web.Mvc.SelectListItem> AcademicYear { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }

        public List<System.Web.Mvc.SelectListItem> Standard { get; set; }


        [Display(Name = "Division")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string div { get; set; }

        public List<System.Web.Mvc.SelectListItem> Division { get; set; }
    }
}