using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Reception
{
    public class PostalDispatch : AuditableEntity<int>
    {
        public string ToTitle { get; set; }
        public string ReferenceNo { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string FromTitle { get; set; }
        public DateTime? Date { get; set; }
        public string DocumentPath { get; set; }
    }
}
