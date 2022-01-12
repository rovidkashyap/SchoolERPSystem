using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Models.HostelViewModel
{
    

    public class HostelViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Hostel Name")]
        public string HostelName { get; set; }

        [Display(Name = "Type")]
        public int HostelTypeId { get; set; }

        [Display(Name = "Type")]
        public string HostelType { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Intake")]
        public string Intake { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}