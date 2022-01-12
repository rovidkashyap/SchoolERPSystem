using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Dependencies.StudentDependencies
{
    public class Category : AuditableEntity<int>
    {
        public string CategoryName { get; set; }
    }
}
