using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
        public class school
        {
            public int schoolID { get; set; }


            [Display(Name = "School Name")]
            [Required(ErrorMessage = "{0} is mandatory.")]
            [RegularExpression("^[a-z . A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
            public string schoolName { get; set; }


            [Display(Name = "School Address")]
            [Required(ErrorMessage = "{0} is mandatory.")]
            [StringLength(200, MinimumLength = 5, ErrorMessage = "{0} should contain minimum 5 and maximum 200 characters.")]
            public string schoolAddress { get; set; }


            [Display(Name = "School Website")]
            [Required(ErrorMessage = "{0} is mandatory.")]
            [Url(ErrorMessage = "Please enter valid {0}.")]
            public string schoolwebsite { get; set; }


            [Display(Name = "Office Number")]
            [Required(ErrorMessage = "{0} is mandatory.")]
            [RegularExpression("^[+0-9]+$", ErrorMessage = "Please enter valid {0}.")]
            public decimal office { get; set; }


            [Display(Name = "Contact Number")]
            [Required(ErrorMessage = "{0} is mandatory.")]
            [RegularExpression("^[+0-9]+$", ErrorMessage = "Please enter valid {0}.")]
            public decimal mobNum { get; set; }
        }
}