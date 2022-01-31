using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class rollAnik
    {
        [Key]
        public int rid { get; set; }
        public string Roll { get; set; }
    }
}