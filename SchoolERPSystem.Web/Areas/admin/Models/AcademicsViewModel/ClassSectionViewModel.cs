using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.AcademicsViewModel
{
    public class ClassSectionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Class Name")]
        public int ClassId { get; set; }

        [Display(Name = "Section Name")]
        public int SectionId { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
    }
}