using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.StaffModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Dependencies
{
    public class Designation : AuditableEntity<int>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

        public IEnumerable<StaffProfile> StaffProfiles { get; set; }
    }
}
