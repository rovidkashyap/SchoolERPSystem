using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Dependencies.SettingDependencies
{
    public class Language : AuditableEntity<int>
    {
        public string LanguageName { get; set; }
        public bool IsActive { get; set; }
    }
}
