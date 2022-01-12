using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StudentModel
{
    public class StudentDocument : AuditableEntity<int>
    {
        public int StudentId { get; set; }

        public string Document1Title { get; set; }
        public string Document1Path { get; set; }

        public string Document2Title { get; set; }
        public string Document2Path { get; set; }

        public string Document3Title { get; set; }
        public string Document3Path { get; set; }

        public string Document4TItle { get; set; }
        public string Document4Path { get; set; }
    }
}
