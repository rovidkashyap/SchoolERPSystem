using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Hostel
{
    public class HostelRoom : AuditableEntity<int>
    {
        public string RoomNumberOrName { get; set; }
        public int HostelId { get; set; }
        public int RoomTypeId { get; set; }
        public int NoOfBed { get; set; }
        public decimal CostPerBed { get; set; }
        public string Description { get; set; }

        public virtual Hostel Hostel { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
