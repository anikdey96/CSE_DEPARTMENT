using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class emFacultyApplication
    {
        [Key]
        public int application_id { get; set; }
        public int? id { get; set; }
        public int? did { get; set; }
   
        [Required(ErrorMessage = "Required Field!!")]
        public string title { get; set; }
   
        public int NoOfLeave { get; set; }
        [Required(ErrorMessage = "Please Specify Your Task!!")]
        public string description { get; set; }
        public string status { get; set; }
        public bool Accepted_Rejected { get; set; }
        [ForeignKey("id")]
        public virtual emFacultyInfo emFacultyInfo { get; set; }
        [ForeignKey("did")]
        public virtual designationEm designationEm { get; set; }
    }
}