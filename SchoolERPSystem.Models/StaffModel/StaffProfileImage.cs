using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StaffModel
{
    public class StaffProfileImage : AuditableEntity<int>
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ProfileImagePath { get; set; }
        public string ProfileImageName { get; set; }
        public string Description { get; set; }
    }
}
