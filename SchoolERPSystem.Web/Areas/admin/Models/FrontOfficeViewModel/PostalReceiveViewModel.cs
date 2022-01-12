using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel
{
    public class PostalReceiveViewModel
    {
        public int Id { get; set; }

        [Display(Name = "From Title")]
        public string FromTitle { get; set; }

        [Display(Name = "Reference No")]
        public string ReferenceNo { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "To Title")]
        public string ToTitle { get; set; }

        [Display(Name = "Date")]
        public DateTime? Date { get; set; }

        [Display(Name = "Attach Document")]
        public string DocumentPath { get; set; }
    }
}