using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Reception
{
    public class Purpose : AuditableEntity<int>
    {
        public string PurposeName { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
