using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StudentModel
{
    public class StudentBanking : AuditableEntity<int>
    {
        public int StudentId { get; set; }

        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string CIFCode { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string LocalIdentificationNumber { get; set; }
        public string PreviousSchoolDetails { get; set; }
        public string Note { get; set; }
    }
}
