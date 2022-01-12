using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Dependencies.SettingDependencies
{
    public class Currency : AuditableEntity<int>
    {
        public string CurrencyName { get; set; }
        public bool IsActive { get; set; }
    }
}
