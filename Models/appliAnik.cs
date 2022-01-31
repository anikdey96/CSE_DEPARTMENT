﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class appliAnik
    {
        [Key]
        public int aid { get; set; }
        public int? nid { get; set; }
        public int? rid { get; set; }
        [Required(ErrorMessage = "Required Field!!")]
        public string title { get; set; }
        public int requiredLeave { get; set; }
        [Required(ErrorMessage = "Please Specify Your Task!!")]
        public string description { get; set; }
        [ForeignKey("nid")]
        public virtual namesAnik namesAnik { get; set; }
        [ForeignKey("rid")]
        public virtual rollAnik rollAnik { get; set; }
    }
}