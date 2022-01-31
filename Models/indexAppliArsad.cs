using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public class indexAppliArsad
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int TotalLeave { get; set; }
        public int LeaveTaken { get; set; }

    }
}