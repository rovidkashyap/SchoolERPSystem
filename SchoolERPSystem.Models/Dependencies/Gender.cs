using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.StaffModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Dependencies
{
    public class Gender : AuditableEntity<int>
    {
        public string GenderName { get; set; }

        public virtual IEnumerable<StaffProfile> StaffProfiles { get; set; }
    }
}
