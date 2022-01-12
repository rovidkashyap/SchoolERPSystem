using SchoolERPSystem.Models.Academics;
using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Models.Dependencies.StudentDependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.StudentModel
{
    public class StudentAdmission : AuditableEntity<int>
    {
        public string AdmissionNumber { get; set; }
        public string RollNumber { get; set; }
        public int ClassNameId { get; set; }
        public int SectionNameId { get; set; }
        public virtual SchoolClass ClassName { get; set; }
        //public virtual ClassSection SectionName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public virtual Gender GenderName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CategoryId { get; set; }
        public virtual Category CategoryName { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string StudentPhoto { get; set; }
        public int BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroupName { get; set; }
        public int StudentHouseId { get; set; }
        public virtual StudentHouse StudentHouseName { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public DateTime AsOnDate { get; set; }

        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }

        public string FatherName { get; set; }
        public string FatherPhone { get; set; }
        public string FatherContact { get; set; }
        public string FatherPhoto { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string MotherPhone { get; set; }
        public string MotherOccupation { get; set; }
        public string MotherPhoto { get; set; }
        public string GuardianType { get; set; }
        public string GuardianName { get; set; }
        public string GuardianRelation { get; set; }
        public string GuardianEmail { get; set; }
        public string GuardianPhoto { get; set; }
        public string GuardianPhone { get; set; }
        public string GuardianOccupation { get; set; }
        public string GuardianAddress { get; set; }

    }
}
