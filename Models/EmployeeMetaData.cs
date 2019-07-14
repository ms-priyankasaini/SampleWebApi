using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApi.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {

    }

    public class EmployeeMetaData
    {
        [Required(ErrorMessage = "Employee id is required")]
        public int id { get; set; }  

        [Required(ErrorMessage = "Job Title is required")]
        public string job_title { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string first_name { get; set; }

        public string last_name { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        public string department { get; set; }


        public string phone { get; set; } 

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; } // Email verification

        [Required(ErrorMessage = "Country is Required")]
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }
}