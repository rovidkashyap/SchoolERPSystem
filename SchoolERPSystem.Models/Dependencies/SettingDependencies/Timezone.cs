using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Dependencies.SettingDependencies
{
    public class Timezone : AuditableEntity<int>
    {
        public string TimezoneName { get; set; }
        public bool IsActive { get; set; }
    }
}
