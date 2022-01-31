using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class appliImrul
    {
        [Key]
        public int aid { get; set; }
        public int? nid { get; set; }

        [Required(ErrorMessage = "Required Field!!")]
        public string title { get; set; }
        public int requiredLeave { get; set; }
        [Required(ErrorMessage = "Please Specify Your Task!!")]
        public string description { get; set; }
        [ForeignKey("nid")]
        public virtual nameImrul nameImrul { get; set; }
      
    }
}