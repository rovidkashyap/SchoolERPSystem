using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StaffModel
{
    public class StaffLeaves : AuditableEntity<int>
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int MedicalLeaves { get; set; }
        public int CasualLeaves { get; set; }
        public int MaternityLeaves { get; set; }

    }
}
