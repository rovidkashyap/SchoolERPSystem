using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Authentication
{
    public class StudentAuthentication : AuditableEntity<int>
    {
        public int StudentId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
