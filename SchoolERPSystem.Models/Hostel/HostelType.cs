using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Hostel
{
    public class HostelType : AuditableEntity<int>
    {
        public string HostelTypeName { get; set; }
    }
}
