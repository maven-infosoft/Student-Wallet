using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class Country
    {
        public int CountryId { get; set; }


        [Display(Name = "Country")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} should be minimum 2 and maximum 20 characters long.")]        
        public string Name { get; set; }
        
        
        public DateTime CreatedDate { get; set; }
        
        
        public string createdByWhom { get; set; }
    }
}