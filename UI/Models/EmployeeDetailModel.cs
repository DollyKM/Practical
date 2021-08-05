using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public partial class EmployeeDetailModel
    {
        public int EmpID { get; set; }
        [Required(ErrorMessage="This field is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Nullable<decimal> TotalExperience { get; set; }
    }
}