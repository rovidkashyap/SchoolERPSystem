using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Authentication
{
    public class UserLog : Entity<int>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string IPAddress { get; set; }
        public DateTime LoginDate { get; set; }
        public string UserAgent { get; set; }
        public string RoleName { get; set; }
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser User { get; set; }

    }
}
