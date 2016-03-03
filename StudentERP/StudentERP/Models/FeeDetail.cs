using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class FeeDetail
    {
        public int yssfID { get; set; }


        public int feeId { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string std { get; set; }

        public List<System.Web.Mvc.SelectListItem> Standards { get; set; }


        [Display(Name = "Shift")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string shft { get; set; }

        public List<System.Web.Mvc.SelectListItem> Shifts { get; set; }


        [Display(Name = "Fees")]
        public string fees { get; set; }


        [Display(Name = "Fees Head")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string feehd { get; set; }

        public List<System.Web.Mvc.SelectListItem> FeesHeading { get; set; }


        [Display(Name = "Amount")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter valid {0}.")]
        public decimal feeamt { get; set; }


        [Display(Name = "Academic Year")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string ay { get; set; }

        public List<System.Web.Mvc.SelectListItem> AcademicYears { get; set; }
    }
}