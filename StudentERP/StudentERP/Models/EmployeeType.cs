
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class EmployeeType
    {
        public int typeId { get; set; }


        [Display(Name = "Employee Type")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} should be minimum 3 and maximum 20 characters long.")]
        public string emptype_name { get; set; }


        public DateTime CreatedDate { get; set; }


        public string createdByWhom { get; set; }
    }
}