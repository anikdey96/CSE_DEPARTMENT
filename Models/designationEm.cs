using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class designationEm
    {
        [Key]
        public int did { get; set; }
        public string Designation { get; set; }
    }
}