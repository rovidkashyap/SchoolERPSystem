using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StaffModel
{
    public class StaffProfile : AuditableEntity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffProfile()
        {
            StaffAttendances = new HashSet<StaffAttendance>();
        }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        public string StaffId { get; set; }
        public string RoleName { get; set; }

        public int DesignationId { get; set; }
        public virtual Designation DesignationName { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department DepartmentName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public int GenderId { get; set; }
        public virtual Gender GenderName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string Mobile { get; set; }
        public string EmergencyContact { get; set; }

        public int MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatusName { get; set; }

        //Address Details

        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Qualification { get; set; }

        public int? WorkExperience { get; set; }
        public string Note { get; set; }

        //Social Media Links

        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string LinkedInURL { get; set; }
        public string InstagramURL { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffAttendance> StaffAttendances { get; set; }

    }
}
