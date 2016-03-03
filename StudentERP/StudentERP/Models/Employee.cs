using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
    public class Employee
    {
        public int EmpId { get; set; }


        [Display(Name = "Employee Type")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public int typeID { get; set; }

        public List<System.Web.Mvc.SelectListItem> EmployeeTypes { get; set; }


        public string type { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Length of the password should be within 6 to 15.")]
        public string Password { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string FirstName { get; set; }


        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string MiddleName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Please enter valid {0}.")]
        public string LastName { get; set; }


        [Display(Name = "Birthdate")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public DateTime Birthdate { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter valid {0}.")]
        public string Email { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public bool Gender { get; set; }


        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid {0}.")]
        public decimal ContactNo { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string Address { get; set; }


        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}