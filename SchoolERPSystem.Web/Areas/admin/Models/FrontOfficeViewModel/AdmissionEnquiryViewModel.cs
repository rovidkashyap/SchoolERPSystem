using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel
{
    public class AdmissionEnquiryViewModel
    {
        public AdmissionEnquiryViewModel()
        {
            Date = DateTime.Now;
            NextFollowUpDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Next Date")]
        public DateTime NextFollowUpDate { get; set; }

        [Display(Name = "Assigned")]
        public string Assigned { get; set; }

        [Display(Name = "Reference")]
        public int ReferenceId { get; set; }
        public string ReferenceName { get; set; }

        [Display(Name = "Source")]
        public int SourceId { get; set; }
        public string SourceName { get; set; }

        [Display(Name = "Class")]
        public int SchoolClassId { get; set; }
        public string SchoolClassName { get; set; }

        [Display(Name = "No Of Child")]
        public int NoOfChild { get; set; }
    }
}