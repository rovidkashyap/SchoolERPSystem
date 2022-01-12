using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.AcademicsViewModel
{
    public class SectionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Section Name")]
        public string SectionName { get; set; }
    }
}