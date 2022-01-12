using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Transport
{
    public class Route : AuditableEntity<int>
    {
        public string RouteTitle { get; set; }
        public decimal Fare { get; set; }
        public string Description { get; set; }
    }
}
