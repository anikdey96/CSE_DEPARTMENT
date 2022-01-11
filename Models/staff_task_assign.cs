using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class staff_task_assign
    {
        [Key]
        public int task_id { get; set; }
        public int? staff_id { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public string title { get; set; }
        [Required(ErrorMessage = "Please Specify Your Task!!")]
        public string description { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime deadline { get; set; }
        public string priority { get; set; }
        //public string status { get; set; }
        public string feedback { get; set; }
        [ForeignKey("staff_id")]
        public virtual Staff Staff { get; set; }
    }
}