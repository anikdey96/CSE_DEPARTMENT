using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class Application
    {
        [Key]
        public int application_id { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public string name { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public int roll { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public string title { get; set; }
        public string tag { get; set; }
        [Required(ErrorMessage = "Please Specify Your Task!!")]
        public string description { get; set; }
  
        public string status { get; set; }
        public int? year_id { get; set; }

        [ForeignKey("year_id")]
        public virtual Year Year { get; set; }
    }
}