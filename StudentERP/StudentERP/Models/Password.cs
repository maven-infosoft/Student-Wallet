using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class Password
    {
        [Display(Name = "Old Password")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [MaxLength(15, ErrorMessage = "Invalid {0}.")]
        [MinLength(6, ErrorMessage = "Invalid {0}.")]
        public string opwd { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [MaxLength(15, ErrorMessage = "Length of the password should be within 6 to 15.")]
        [MinLength(6, ErrorMessage = "Length of the password should be within 6 to 15.")]
        public string npwd { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [Compare("New Password", ErrorMessage = "Both the passwords should be same.")]
        public string cpwd { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string email { get; set; }
    }
}