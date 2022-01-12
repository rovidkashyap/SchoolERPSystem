using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Dependencies.SettingDependencies
{
    public class Session : AuditableEntity<int>
    {
        public string SessionName { get; set; }
        public bool isActive { get; set; }
    }
}
