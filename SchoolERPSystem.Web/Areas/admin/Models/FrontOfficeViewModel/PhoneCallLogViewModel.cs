using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel
{
    public class PhoneCallLogViewModel
    {
        public PhoneCallLogViewModel()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Date")]
        public DateTime? Date { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Next Date")]
        public DateTime? NextDate { get; set; }

        [Display(Name = "Call Duration")]
        public int CallDuration { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Call Type")]
        public string CallType { get; set; }
    }
}