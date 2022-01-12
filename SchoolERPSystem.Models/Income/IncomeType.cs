using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Income
{
    public class IncomeType : AuditableEntity<int>
    {
        public string IncomeHead { get; set; }
        public string Description { get; set; }
    }
}
