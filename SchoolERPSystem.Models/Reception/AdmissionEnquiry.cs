using SchoolERPSystem.Models.Academics;
using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Reception
{
    public class AdmissionEnquiry : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public DateTime NextFollowUpDate { get; set; }
        public string Assigned { get; set; }
        public int ReferenceId { get; set; }
        public Reference ReferenceName { get; set; }
        public int SourceId { get; set; }
        public Source SourceName { get; set; }
        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClassName { get; set; }
        public int NoOfChild { get; set; }
    }
}
