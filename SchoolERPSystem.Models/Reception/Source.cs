using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Reception
{
    public class Source : AuditableEntity<int>
    {
        public string SourceName { get; set; }
        public string SourceDescription { get; set; }

        public bool IsActive { get; set; }
    }
}
