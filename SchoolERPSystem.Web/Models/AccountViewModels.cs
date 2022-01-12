using SchoolERPSystem.Models.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolERPSystem.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "UserRoles")]
        public string UserRoles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //Staff Profile View Model

        public int Id { get; set; }
        public string ApplicationUserId { get; set; }

        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string StaffId { get; set; }

        public int DesignationId { get; set; }

        [DisplayName("Designation")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string DesignationName { get; set; }

        public int DepartmentId { get; set; }

        [DisplayName("Department")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string DepartmentName { get; set; }

        [DisplayName("First Name")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string LastName { get; set; }

        [DisplayName("Father Name")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string FatherName { get; set; }

        [DisplayName("Mother Name")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string MotherName { get; set; }

        public int GenderId { get; set; }

        [DisplayName("Gender")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string GenderName { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "-- Not Specified --")]
        public DateTime? DateOfBirth { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "-- Not Specified --")]
        public DateTime? DateOfJoining { get; set; }

        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string Mobile { get; set; }

        [DisplayName("Emergency Contact")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string EmergencyContact { get; set; }

        public int MaritalStatusId { get; set; }

        [DisplayName("Marital")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string MaritalStatusName { get; set; }

        //Address Details

        [DisplayName("Current Address")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string CurrentAddress { get; set; }

        [DisplayName("Permanent Address")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string PermanentAddress { get; set; }

        [DisplayName("Qualification")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string Qualification { get; set; }

        [DisplayName("Work Experience")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public int WorkExperience { get; set; }

        [DisplayName("Note")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string Note { get; set; }

        //Social Media Links

        [DisplayName("Facebook URL")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string FacebookURL { get; set; }

        [DisplayName("Twitter URL")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string TwitterURL { get; set; }

        [DisplayName("LinkedIn URL")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string LinkedInURL { get; set; }

        [DisplayName("Instagram URL")]
        [DisplayFormat(NullDisplayText = "-- Not Specified --")]
        public string InstagramURL { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
