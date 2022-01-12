using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Models.AcademicsViewModel
{
    
    public class SubjectViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
        public string SubjectType { get; set; }

        [Display(Name = "Subject Code")]
        public string SubjectCode { get; set; }
    }
}