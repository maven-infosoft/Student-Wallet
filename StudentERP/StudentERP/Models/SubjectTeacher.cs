using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class SubjectTeacher
    {
        public int subjectteacherId { get; set; }


        [Display(Name = "Subject")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string sub { get; set; }

        public List<System.Web.Mvc.SelectListItem> Subjects { get; set; }


        [Display(Name = "Teacher Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string tname { get; set; }

        public List<System.Web.Mvc.SelectListItem> Teachers { get; set; }


        [Display(Name = "Acadamic Year")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string acadyear { get; set; }

        public List<System.Web.Mvc.SelectListItem> AcademicYears { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }

        public List<System.Web.Mvc.SelectListItem> Standards { get; set; }


        [Display(Name = "Division")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string div { get; set; }

        public List<System.Web.Mvc.SelectListItem> Division { get; set; }
    }
}