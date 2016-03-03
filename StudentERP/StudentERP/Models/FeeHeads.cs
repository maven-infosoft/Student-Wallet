using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class FeeHeads
    {
        public int fhID { get; set; }


        [Display(Name = "Fee Title")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string fhName { get; set; }


        public DateTime CreatedDate { get; set; }


        public string createdByWhom { get; set; }
    }
}