using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentERP.Models
{
        public class Board
        {
            public int bID { get; set; }


            [Display(Name = "Board Name")]
            [Required(ErrorMessage = "{0} is mandatory.")]
            [RegularExpression("^[a-z A-Z]+$", ErrorMessage="Please enter valid {0}.")]
            [StringLength(20, MinimumLength = 3, ErrorMessage="{0} should be minimum 3 and maximum 20 characters long.")]
            public string bName { get; set; }


            public DateTime CreatedDate { get; set; }


            public string CreatedByWhom { get; set; }
        }

        public class BoardSchoolMapping
        {
            public int bsid { get; set; }


            [Display(Name = "Board")]
            [Required(ErrorMessage = "{0} is mandatory.")]
            public int bid { get; set; }

            public IEnumerable<System.Web.Mvc.SelectListItem> BoardId { get; set; }


            [Display(Name = "School")]
            [Required(ErrorMessage = "{0} is mandatory.")]
            public int sid { get; set; }

            public IEnumerable<System.Web.Mvc.SelectListItem> SchoolId { get; set; }


            [Display(Name = "Board")]
            public string bname { get; set; }



            [Display(Name = "School")]
            public string sname { get; set; }
        }
}