using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Academics
{
    public class Subject : AuditableEntity<int>
    {
        public string SubjectName { get; set; }
        public string SubjectType { get; set; }
        public string SubjectCode { get; set; }
    }
}
