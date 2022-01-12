using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.AcademicsViewModel
{
    public class SchoolClassViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
    }
}