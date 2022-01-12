using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.student.Models.StudentAdmissionViewModels
{
    public class StudentAdmissionViewModel
    {
        public static string GenerateRandomNumber(int textLength)
        {
            const string Chars = "0123456789";
            var random = new Random();
            var result = new string(
                    Enumerable.Repeat(Chars, textLength)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return result;
        }

        public StudentAdmissionViewModel()
        {
            AdmissionNumber = GenerateRandomNumber(10);
        }

        public int Id { get; set; }

        [Display(Name = "Admission Number")]
        public string AdmissionNumber { get; set; }

        [Display(Name = "Roll Number")]
        public string RollNumber { get; set; }

        [Display(Name = "Class")]
        public int ClassId { get; set; }

        [Display(Name = "Section")]
        public int SectionId { get; set; }

        [Display(Name = "Class")]
        public string ClassName { get; set; }

        [Display(Name = "Section")]
        public string SectionName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Display(Name = "Gender")]
        public string GenderName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "-- Not Specified --")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Religion")]
        public string Religion { get; set; }

        [Display(Name = "Caste")]
        public string Caste { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Admission Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "-- Not Specified --")]
        public DateTime AdmissionDate { get; set; }

        [Display(Name = "Student Photo")]
        public string StudentPhoto { get; set; }

        [Display(Name = "Blood Group")]
        public int BloodGroupId { get; set; }

        [Display(Name = "Blood Group")]
        public string BloodGroupName { get; set; }

        [Display(Name = "Student House")]
        public int StudentHouseId { get; set; }

        [Display(Name = "Student House")]
        public string StudentHouseName { get; set; }

        [Display(Name = "Height")]
        public decimal Height { get; set; }

        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

        [Display(Name = "As On Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "-- Not Specified --")]
        public DateTime AsOnDate { get; set; }

        [Display(Name = "Current Address")]
        public string CurrentAddress { get; set; }

        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        // Student Banking
        [Display(Name = "Bank Account Number")]
        public string BankAccountNumber { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Display(Name = "IFSC Code")]
        public string IFSCCode { get; set; }

        [Display(Name = "CIF Code")]
        public string CIFCode { get; set; }

        [Display(Name = "National Identification Number")]
        public string NationalIdentificationNumber { get; set; }

        [Display(Name = "Local Identification Number")]
        public string LocalIdentificationNumber { get; set; }

        [Display(Name = "Previous School Details")]
        public string PreviousSchoolDetails { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        // Student Document
        [Display(Name = "Title")]
        public string Document1Title { get; set; }

        [Display(Name = "Documents")]
        public string Document1Path { get; set; }

        [Display(Name = "Title")]
        public string Document2Title { get; set; }

        [Display(Name = "Documents")]
        public string Document2Path { get; set; }

        [Display(Name = "Title")]
        public string Document3Title { get; set; }

        [Display(Name = "Documents")]
        public string Document3Path { get; set; }

        [Display(Name = "Title")]
        public string Document4TItle { get; set; }

        [Display(Name = "Documents")]
        public string Document4Path { get; set; }

        // Student Hostel
        [Display(Name = "Hostel")]
        public int HostelId { get; set; }

        [Display(Name = "Hostel")]
        public string HostelName { get; set; }

        [Display(Name = "Room Number")]
        public int RoomId { get; set; }

        [Display(Name = "Room Number")]
        public string RoomName { get; set; }

        // Student Parent
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Display(Name = "Father Phone")]
        public string FatherPhone { get; set; }

        [Display(Name = "Father Contact")]
        public string FatherContact { get; set; }

        [Display(Name = "Father Occupation")]
        public string FatherOccupation { get; set; }

        [Display(Name = "Father Photo")]
        public string FatherPhoto { get; set; }

        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        [Display(Name = "Mother Phone")]
        public string MotherPhone { get; set; }

        [Display(Name = "Mother Occupation")]
        public string MotherOccupation { get; set; }

        [Display(Name = "Mother Photo")]
        public string MotherPhoto { get; set; }

        [Display(Name = "If Guardian Is")]
        public string GuardianType { get; set; }

        [Display(Name = "Guardian Name")]
        public string GuardianName { get; set; }

        [Display(Name = "Guardian Relation")]
        public string GuardianRelation { get; set; }

        [Display(Name = "Guardian Email")]
        public string GuardianEmail { get; set; }

        [Display(Name = "Guardian Photo")]
        public string GuardianPhoto { get; set; }

        [Display(Name = "Guardian Phone")]
        public string GuardianPhone { get; set; }

        [Display(Name = "Guardian Occupation")]
        public string GuardianOccupation { get; set; }

        [Display(Name = "Guardian Address")]
        public string GuardianAddress { get; set; }

        // Student Transport
        [Display(Name = "Route List")]
        public int VehicleRouteId { get; set; }

        [Display(Name = "Route List")]
        public string VehicleRouteName { get; set; }
    }
}