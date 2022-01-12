using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Reception
{
    public class Reference : AuditableEntity<int>
    {
        public string ReferenceName { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
