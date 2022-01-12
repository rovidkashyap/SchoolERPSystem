using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Reception
{
    public class PhoneCallLog : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public DateTime? NextDate { get; set; }
        public int CallDuration { get; set; }
        public string Note { get; set; }
        public string CallType { get; set; }
    }
}
