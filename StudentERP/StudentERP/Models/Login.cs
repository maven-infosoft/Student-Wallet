using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class Login
    {
        public int loginId { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter valid {0}.")]
        public string email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Length of the password should be within 6 to 15.")]
        public string pwd { get; set; }
    }
}