using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class Standard
    {
        public int StandardId { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter valid {0}.")]
        public string name { get; set; }


        [Display(Name = "Level")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter valid {0}.")]
        public int LevelOfStd { get; set; }
    }

    public class StandardDivisionMapping
    {
        public int standivid { get; set; }


        [Display(Name = "Standard")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[0-9 a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string std { get; set; }

        public List<System.Web.Mvc.SelectListItem> Standards { get; set; }


        [Display(Name = "Division")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string divi { get; set; }

        public List<System.Web.Mvc.SelectListItem> Divisions { get; set; }


        [Display(Name = "Acadamic Year")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string Year { get; set; }

        public List<System.Web.Mvc.SelectListItem> Years { get; set; }
    }
}