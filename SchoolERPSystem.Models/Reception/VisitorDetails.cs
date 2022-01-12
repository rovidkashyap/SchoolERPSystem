using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Reception
{
    public class VisitorDetails : AuditableEntity<int>
    {

        public int PurposeId { get; set; }
        public virtual Purpose PurposeName { get; set; }

        public string FullName { get; set; }
        public string Phone { get; set; }
        public string IdentiyCardNumber { get; set; }
        public int NoOfPerson { get; set; }
        public DateTime? VisitingDate { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public string Note { get; set; }
        public string DocumentSubmitted { get; set; }
    }
}
