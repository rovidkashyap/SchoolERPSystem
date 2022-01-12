using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Academics
{
    public class ClassSection : AuditableEntity<int>
    {
        public int ClassNameId { get; set; }
        public int SectionNameId { get; set; }

        public virtual SchoolClass ClassName { get; set; }
        public virtual Section SectionName { get; set; }
    }
}
