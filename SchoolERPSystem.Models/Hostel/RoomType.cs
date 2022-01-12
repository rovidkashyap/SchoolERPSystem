using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Hostel
{
    public class RoomType : AuditableEntity<int>
    {
        public string RoomTypeName { get; set; }
        public string Description { get; set; }
    }
}
