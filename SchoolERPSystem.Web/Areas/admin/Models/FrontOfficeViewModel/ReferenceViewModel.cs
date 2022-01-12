using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel
{
    public class ReferenceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Reference")]
        public string ReferenceName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}