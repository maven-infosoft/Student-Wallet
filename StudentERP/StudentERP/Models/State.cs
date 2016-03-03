using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class State
    {
        [Display(Name = "Country")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string cntry { get; set; }


        [Display(Name = "State")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} should be minimum 3 and maximum 20 characters long.")]
        public string stat { get; set; }
    }
}