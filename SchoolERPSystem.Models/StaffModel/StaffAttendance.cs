using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StaffModel
{
    public class StaffAttendance : AuditableEntity<int>
    {

        public int StaffProfileId { get; set; }
        public string Attendance { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? IsHoliday { get; set; }
        public string Note { get; set; }

        //public virtual StaffProfile Staff { get; set; }
    }
}
