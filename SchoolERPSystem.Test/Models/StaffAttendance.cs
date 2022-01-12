namespace SchoolERPSystem.Test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StaffAttendance
    {
        public int Id { get; set; }

        public int? StaffId { get; set; }

        [StringLength(50)]
        public string Attendance { get; set; }

        public DateTime? AttendanceDate { get; set; }

        public bool? IsHoliday { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

        public virtual StaffProfile StaffProfile { get; set; }
    }
}
