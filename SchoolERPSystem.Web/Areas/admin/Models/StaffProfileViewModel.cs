using SchoolERPSystem.Models.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.Admin.Models
{
    public class StaffProfileViewModel
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
        public StaffProfileViewModel()
        {
            StaffId = GenerateRandomNumber(7);
            MaternityLeaves = 0;
            CasualLeaves = 0;
            MedicalLeaves = 0;
            BasicSalary = 0;
            WorkExperience = 0;
            ContractTypeId = 0;
        }

        [Required]
        [Display(Name = "Role")]
        public string UserRoles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //Staff Profile View Model
        public string ApplicationUserId { get; set; }

        [Display(Name = "Staff ID")]
        [DisplayFormat(NullDisplayText = "--")]
        public string StaffId { get; set; }

        public int DesignationId { get; set; }

        [DisplayName("Designation")]
        [DisplayFormat(NullDisplayText = "--")]
        public string DesignationName { get; set; }

        public int DepartmentId { get; set; }

        [DisplayName("Department")]
        [DisplayFormat(NullDisplayText = "--")]
        public string DepartmentName { get; set; }

        [DisplayName("First Name")]
        [DisplayFormat(NullDisplayText = "--")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [DisplayFormat(NullDisplayText = "--")]
        public string LastName { get; set; }

        [DisplayName("Father Name")]
        [DisplayFormat(NullDisplayText = "--")]
        public string FatherName { get; set; }

        [DisplayName("Mother Name")]
        [DisplayFormat(NullDisplayText = "--")]
        public string MotherName { get; set; }

        public int GenderId { get; set; }

        [DisplayName("Gender")]
        [DisplayFormat(NullDisplayText = "--")]
        public string GenderName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "-- Not Specified --")]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "-- Not Specified --")]
        public DateTime? DateOfJoining { get; set; }

        [DisplayFormat(NullDisplayText = "--")]
        public string Mobile { get; set; }

        [DisplayName("Emergency Contact")]
        [DisplayFormat(NullDisplayText = "--")]
        public string EmergencyContact { get; set; }

        public int MaritalStatusId { get; set; }

        [DisplayName("Marital")]
        [DisplayFormat(NullDisplayText = "--")]
        public string MaritalStatusName { get; set; }

        //Address Details

        [DisplayName("Current Address")]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "--")]
        public string CurrentAddress { get; set; }

        [DisplayName("Permanent Address")]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "--")]
        public string PermanentAddress { get; set; }

        [DisplayName("Qualification")]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "--")]
        public string Qualification { get; set; }

        [DisplayName("Work Experience")]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "--")]
        [DefaultValue(0)]
        public int? WorkExperience { get; set; }

        [DisplayName("Note")]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "--")]
        public string Note { get; set; }

        //Social Media Links

        [DisplayName("Facebook URL")]
        [DisplayFormat(NullDisplayText = "--")]
        public string FacebookURL { get; set; }

        [DisplayName("Twitter URL")]
        [DisplayFormat(NullDisplayText = "--")]
        public string TwitterURL { get; set; }

        [DisplayName("LinkedIn URL")]
        [DisplayFormat(NullDisplayText = "--")]
        public string LinkedInURL { get; set; }

        [DisplayName("Instagram URL")]
        [DisplayFormat(NullDisplayText = "--")]
        public string InstagramURL { get; set; }

        //Staff Payroll Model

        [Display(Name = "EPF Number")]
        public string StaffEPFNo { get; set; }

        [DefaultValue(0.0)]
        [Display(Name = "Basic Salary")]
        public decimal BasicSalary { get; set; }

        [Display(Name = "Contract Type")]
        public int ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }

        [Display(Name = "Work Shift")]
        public string WorkShift { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        //Staff Leaves Model

        [Display(Name = "Medical Leave")]
        public int MedicalLeaves { get; set; }

        [Display(Name = "Casual Leave")]
        public int CasualLeaves { get; set; }

        [Display(Name = "Maternity Leave")]
        public int MaternityLeaves { get; set; }

        //Staff Bank Details Model

        [Display(Name = "Account Title")]
        public string AccountTitle { get; set; }

        [Display(Name = "Bank Account Number")]
        public string BankAccountNumber { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Display(Name = "IFSC Code")]
        public string IFSCCode { get; set; }

        [Display(Name = "Bank Branch Name")]
        public string BankBranchName { get; set; }

        //Staff Documents Model

        [Display(Name = "Resume")]
        public string ResumeName { get; set; }
        public string ResumePath { get; set; }

        [Display(Name = "Joining Letter")]
        public string JoiningLetterName { get; set; }
        public string JoiningLetterPath { get; set; }

        [Display(Name = "Other Document")]
        public string OtherDocumentName { get; set; }
        public string OtherDocumentPath { get; set; }

        //Staff Profile Image Model

        public string ProfileImagePath { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfileImageName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        //User Counts 

        public int superadminCount { get; set; }
        public int adminCount { get; set; }
        public int accountantCount { get; set; }
        public int librarianCount { get; set; }
        public int receptionistCount { get; set; }
        public int teacherCount { get; set; }

        public int studentCount { get; set; }
    }
}