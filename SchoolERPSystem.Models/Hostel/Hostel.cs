using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Hostel
{

    public class Hostel : AuditableEntity<int>
    {
        public string HostelName { get; set; }
        public int HostelTypeId { get; set; }
        public virtual HostelType HostelType { get; set; }
        public string Address { get; set; }
        public string Intake { get; set; }
        public string Description { get; set; }
    }
}
