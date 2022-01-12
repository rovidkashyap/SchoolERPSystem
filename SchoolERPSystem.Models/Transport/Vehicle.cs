using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Transport
{
    public class Vehicle : AuditableEntity<int>
    {
        public string VehicleNumber { get; set; }
        public string VehicleModel { get; set; }
        public string YearMade { get; set; }
        public string DriverName { get; set; }
        public string DriverLicense { get; set; }
        public string DriverContact { get; set; }
        public string Note { get; set; }
    }
}
