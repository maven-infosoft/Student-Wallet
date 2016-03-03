using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class shift
    {
        public int shiftId { get; set; }


        [Display(Name = "Shift Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string shiftName { get; set; }

        public DateTime CreatedDate { get; set; }
        public string createdByWhom { get; set; }
    }

    public class StandardDivisionShiftMapping
    {
        public int sdsID { get; set; }

        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }

        public List<System.Web.Mvc.SelectListItem> Standards { get; set; }


        [Display(Name = "Shift")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string shft { get; set; }

        public List<System.Web.Mvc.SelectListItem> Shifts { get; set; }


        [Display(Name = "Division")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string div { get; set; }

        public List<System.Web.Mvc.SelectListItem> Divisions { get; set; }


        [Display(Name = "Acadamic Year")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string ayear { get; set; }

        public List<System.Web.Mvc.SelectListItem> AcademicYears { get; set; }


        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[0-9 :]+$", ErrorMessage = "Please enter valid {0}.")]
        public string stime { get; set; }


        [Display(Name = "End Time")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[0-9 :]+$", ErrorMessage = "Please enter valid {0}.")]
        public string etime { get; set; }
    }
}