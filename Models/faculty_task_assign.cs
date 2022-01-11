using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class faculty_task_assign
    {
        [Key]
        public int task_id { get; set; }
        public int? teacher_id { get; set; }
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
        [ForeignKey("teacher_id")]
        public virtual teacher teacher { get; set; }
    }
}