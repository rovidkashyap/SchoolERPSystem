using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Reception
{
    public class ComplainType : AuditableEntity<int>
    {
        public string ComplainName { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
