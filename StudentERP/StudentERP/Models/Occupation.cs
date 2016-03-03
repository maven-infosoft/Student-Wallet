
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class Occupation
    {
        public int OccupationId { get; set; }


        [Display(Name = "Occupation")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string name { get; set; }
    }
}