using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class student_task_assign
    {
        [Key]
        public int task_id { get; set; }
        //public int? currentacademic_id { get; set; }
        public int? student_id { get; set; }
        //public int? session_id { get; set; }
        public int? year_id { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public int roll { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public string title { get; set; }
        [Required(ErrorMessage = "Please Specify Your Task!!")]
        public string description { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime deadline { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public string priority { get; set; }
        //public string status { get; set; }
        public string feedback { get; set; }
        //[ForeignKey("session_id")]
        //public virtual Session Session { get; set; }
        [ForeignKey("student_id")]
        public virtual student student { get; set; }
        [ForeignKey("year_id")]
        public virtual Year Year { get; set; }
        //[ForeignKey("currentacademic_id")]
        //public virtual current_academic Current_Academic { get; set; }
    }
}