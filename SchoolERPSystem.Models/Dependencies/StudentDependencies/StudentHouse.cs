using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Dependencies.StudentDependencies
{
    public class StudentHouse : AuditableEntity<int>
    {
        public string StudentHouseName { get; set; }
    }
}
