using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StaffModel
{
    public class StaffDocuments : AuditableEntity<int>
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ResumeName { get; set; }
        public string ResumePath { get; set; }

        public string JoiningLetterName { get; set; }
        public string JoiningLetterPath { get; set; }

        public string OtherDocumentName { get; set; }
        public string OtherDocumentPath { get; set; }
    }
}
