using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class City
    {
        [Display(Name = "State")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string stat { get; set; }

        public List<System.Web.Mvc.SelectListItem> States { get; set; }


        [Display(Name = "City")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} should be minimum 3 and maximum 20 characters long.")]
        public string cty { get; set; }


        public int sid { get; set; }


        public int cid { get; set; }


        public DateTime CreatedDate { get; set; }


        public string createdByWhom { get; set; }
    }
}