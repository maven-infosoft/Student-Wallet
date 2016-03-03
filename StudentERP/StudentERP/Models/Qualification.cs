using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }


        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z . A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string Name { get; set; }
    }
}