using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Academics
{
    public class SchoolClass : AuditableEntity<int>
    { 

        public string ClassName { get; set; }

    }
}
