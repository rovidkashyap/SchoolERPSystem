using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.HRViewModel
{
    public class StaffAttendanceViewModel
    {
        public StaffAttendanceViewModel()
        {
            AttendanceDate = DateTime.Now;
            IsHoliday = false;
        }
        public int Id { get; set; }
        public int StaffProfileId { get; set; }
        public string Attendance { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? IsHoliday { get; set; }
        public string Note { get; set; }


        
    }
}