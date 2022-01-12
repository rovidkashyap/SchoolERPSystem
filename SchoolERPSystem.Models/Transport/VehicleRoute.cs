using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Transport
{
    public class VehicleRoute : AuditableEntity<int>
    {
        public int RouteId { get; set; }
        public int VehicleId { get; set; }

        public virtual Route Route { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
