using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }


        [Display(Name = "Subject")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string Name { get; set; }
    }

    public class StandardSubjectMapping
    {
        public int std_sub_ID { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }

        public List<System.Web.Mvc.SelectListItem> Standards { get; set; }


        [Display(Name = "Subject")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string sub { get; set; }

        public List<System.Web.Mvc.SelectListItem> Subjects { get; set; }


        [Display(Name = "Acadamic Year")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string aca { get; set; }

        public List<System.Web.Mvc.SelectListItem> AcademicYears { get; set; }


        [Display(Name = "Type Of Subject")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public bool Type { get; set; }
    }
}