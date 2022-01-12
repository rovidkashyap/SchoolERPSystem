using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.Hostel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StudentModel
{
    public class StudentHostel : AuditableEntity<int>
    {
        public int StudentId { get; set; }

        public int HostelId { get; set; }
        public virtual Hostel.Hostel HostelName { get; set; }

        public int RoomNameId { get; set; }
        //public virtual HostelRoom RoomName { get; set; }
    }
}
