﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public class routine41
    {
        [Key]
        public int routine_id { get; set; }

        //public string routine_upload { get; set; }
        //[Required(ErrorMessage = "This Is A Required Field!!")]
        //[DataType(DataType.Date)]
        //public System.DateTime class_date { get; set; }
        //[Required(ErrorMessage = "This Is A Required Field!!")]
        //public string day { get; set; }
        //public int? teacher_id { get; set; }
        //public int? subject_id { get; set; }
        public int? year_id { get; set; }
        public int? session_id { get; set; }

        //[Required(ErrorMessage = "This Is A Required Field!!")]
        //[DataType(DataType.Time)]
        //public System.TimeSpan start_time { get; set; }
        //[Required(ErrorMessage = "This Is A Required Field!!")]
        //[DataType(DataType.Time)]
        //public System.TimeSpan end_time { get; set; }
        //[Required(ErrorMessage = "This Is A Required Field!!")]
        //public string duration { get; set; }
        public string comment { get; set; }

        [ForeignKey("session_id")]
        public virtual Session Session { get; set; }
        [ForeignKey("year_id")]
        public virtual Year Year { get; set; }
        //[ForeignKey("subject_id")]
        //public virtual Subject Subject { get; set; }
        //[ForeignKey("teacher_id")]
        //public virtual teacher teacher { get; set; }

        public IEnumerable<HttpPostedFileBase> files { get; set; }
    }
}