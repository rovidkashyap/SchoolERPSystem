using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Reception
{
    public class ComplainDetails : AuditableEntity<int>
    {

        public int ComplainTypeId { get; set; }
        public virtual ComplainType ComplainType { get; set; }

        public int SourceId { get; set; }
        public virtual Source Source { get; set; }

        public string ComplainBy { get; set; }
        public string Phone { get; set; }
        public DateTime? ComplainDate { get; set; }
        public string Description { get; set; }
        public string ActionTaken { get; set; }
        public string Assigned { get; set; }
        public string Note { get; set; }
        public string Documents { get; set; }

        public bool IsActive { get; set; }
    }
}
