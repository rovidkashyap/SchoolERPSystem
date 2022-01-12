using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StaffModel
{
    public class StaffBankDetails : AuditableEntity<int>
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string AccountTitle { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string BankBranchName { get; set; }
    }
}
