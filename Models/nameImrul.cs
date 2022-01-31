using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class nameImrul
    {
        [Key]
        public int nid { get; set; }
        public string Name { get; set; }
    }
}