using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StudentModel
{
    public class StudentTransport : AuditableEntity<int>
    {
        public int StudentId { get; set; }

        public int VehicleRouteId { get; set; }
        public virtual VehicleRoute VehicleRouteName { get; set; }
    }
}
