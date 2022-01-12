using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StaffModel
{
    public class StaffPayroll : AuditableEntity<int>
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string StaffEPFNo { get; set; }
        public decimal BasicSalary { get; set; }

        public int ContractTypeId { get; set; }
        public virtual ContractType ContractTypeName { get; set; }

        public string WorkShift { get; set; }
        public string Location { get; set; }
    }
}
