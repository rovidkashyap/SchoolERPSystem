using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Reception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel
{
    public class ComplaintViewModel
    {
        public ComplaintViewModel()
        {
            ComplainDate = DateTime.Now;
        }
        public int Id { get; set; }

        [Display(Name = "Complain Type")]
        public int ComplainTypeId { get; set; }
        public string ComplainType { get; set; }

        [Display(Name = "Source")]
        public int SourceId { get; set; }
        public string Source { get; set; }

        [Display(Name = "Complain By")]
        public string ComplainBy { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Date")]
        //[DataType(DataType.Date)]
        public DateTime? ComplainDate { get; set; }
        public string Description { get; set; }

        [Display(Name = "Action Taken")]
        public string ActionTaken { get; set; }

        [Display(Name = "Assigned To")]
        public string Assigned { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Attach Document")]
        public string Documents { get; set; }

        public bool IsActive { get; set; }
    }
}