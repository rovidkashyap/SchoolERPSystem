using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel
{
    public class VisitorBookViewModel
    {
        public VisitorBookViewModel()
        {
            VisitingDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int PurposeId { get; set; }

        [Display(Name = "Purpose")]
        public string PurposeName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }
        public string Phone { get; set; }

        [Display(Name = "ID Card")]
        public string IdentiyCardNumber { get; set; }

        [Display(Name = "No. Of Person")]
        public int NoOfPerson { get; set; }

        [Display(Name = "Date")]
        public DateTime? VisitingDate { get; set; }

        [Display(Name = "In Time")]
        public DateTime? InTime { get; set; }

        [Display(Name = "Out Time")]
        public DateTime? OutTime { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Attach Document")]
        public string DocumentSubmitted { get; set; }
    }
}