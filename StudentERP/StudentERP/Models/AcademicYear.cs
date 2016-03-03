using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class AcademicYear
    {
        public int academicId { get; set; }


        [Display(Name = "Year")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "{0} should be minimum 8 and maximum 10 characters long.")]
        [RegularExpression("^[0-9 -]+$", ErrorMessage = "Please enter valid {0}.")]
        public string Year { get; set; }


        [Display(Name = "Is Active Year")]
        public bool isact { get; set; }


        public DateTime CreatedDate { get; set; }


        public String createdByWhom { get; set; }
    }
    public class AcademicYearStandardMapping
    {
        public int yearStandardId { get; set; }


        [Display(Name = "Start Month")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string smonth { get; set; }

        public List<System.Web.Mvc.SelectListItem> StartMonths { get; set; }


        [Display(Name = "End Month")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string emonth { get; set; }

        public List<System.Web.Mvc.SelectListItem> EndMonths { get; set; }


        [Display(Name = "Acadamic Year")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string ayear { get; set; }

        public List<System.Web.Mvc.SelectListItem> AcademicYears { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string astd { get; set; }

        public List<System.Web.Mvc.SelectListItem> Standards { get; set; }
    }
}