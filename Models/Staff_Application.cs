using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class Staff_Application
    {
        [Key]
        public int application_id { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public string name { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public string title { get; set; }
        public string tag { get; set; }
        [Required(ErrorMessage = "Please Specify Your Task!!")]
        public string description { get; set; }
        public string status { get; set; }
    }
}