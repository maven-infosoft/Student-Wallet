using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class Division
    {
        public int DivisonID { get; set; }

        [Display(Name = "Division")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [DataType(DataType.Text, ErrorMessage = "Please enter valid {0}.")]
        public string Name { get; set; }


        public DateTime CreatedDate { get; set; }
        
        
        public string createdByWhom { get; set; }
    }
}