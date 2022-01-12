using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel
{
    public class ComplaintTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Complain Type")]
        public string ComplainName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}