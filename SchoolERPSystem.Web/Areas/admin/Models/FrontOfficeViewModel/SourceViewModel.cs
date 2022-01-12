using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel
{
    public class SourceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Source")]
        public string SourceName { get; set; }

        [Display(Name = "Description")]
        public string SourceDescription { get; set; }

        public bool IsActive { get; set; }
    }
}