using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.StaffModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Dependencies
{
    public class MaritalStatus : AuditableEntity<int>
    {
        public string MaritalStatusName { get; set; }

        public virtual IEnumerable<StaffProfile> StaffProfiles { get; set; }
    }
}
