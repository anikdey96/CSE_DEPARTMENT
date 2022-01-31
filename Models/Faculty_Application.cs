using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class Faculty_Application
    {
        [Key]
        public int application_id { get; set; }
        //public virtual string Id { get; set; }

        public string name { get; set; }
        [Required(ErrorMessage = "Required Field!!")]

        public string Designation { get; set; }
        public string title { get; set; }
       
        public int NoOfLeave { get; set; }
        [Required(ErrorMessage = "Please Specify Your Task!!")]
        public string description { get; set; }
        public string status { get; set; }
        public bool Accepted_Rejected { get; set; }
        
    }
}