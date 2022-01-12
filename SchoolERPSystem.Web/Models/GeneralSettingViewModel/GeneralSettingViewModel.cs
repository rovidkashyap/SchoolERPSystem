using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Models.GeneralSettingViewModel
{
    public class GeneralSettingViewModel
    {
        public GeneralSettingViewModel()
        {
            SessionId = 0;
            TimezoneId = 0;
            LanguageId = 0;
            CurrencyId = 0;
            FeesDueDays = 0;
        }
        public int Id { get; set; }

        [Display(Name = "School Name")]
        [DisplayFormat(NullDisplayText = "----")]
        public string SchoolName { get; set; }

        [Display(Name = "School Code")]
        [DisplayFormat(NullDisplayText = "----")]
        public string SchoolCode { get; set; }

        [Display(Name = "Address")]
        [DisplayFormat(NullDisplayText = "----")]
        public string SchoolAddress { get; set; }

        [Display(Name = "Phone")]
        [DisplayFormat(NullDisplayText = "----")]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "Alternate Phone")]
        [DisplayFormat(NullDisplayText = "----")]
        public string PhoneNumber2 { get; set; }

        [Display(Name = "Email")]
        [DisplayFormat(NullDisplayText = "----")]
        public string SchoolEmail { get; set; }

        [Display(Name = "Session")]
        [DisplayFormat(NullDisplayText = "----")]
        public int? SessionId { get; set; }

        [Display(Name = "Session Start Month")]
        [DisplayFormat(NullDisplayText = "----")]
        public string SessionStartMonth { get; set; }

        [Display(Name = "Language")]
        [DisplayFormat(NullDisplayText = "----")]
        public int? LanguageId { get; set; }

        [Display(Name = "Timezone")]
        [DisplayFormat(NullDisplayText = "----")]
        public int? TimezoneId { get; set; }

        [Display(Name = "Currency")]
        [DisplayFormat(NullDisplayText = "----")]
        public int? CurrencyId { get; set; }

        [Display(Name = "Currency Symbol")]
        [DisplayFormat(NullDisplayText = "----")]
        public string CurrencySymbol { get; set; }

        [Display(Name = "Fees Due Days")]
        public int? FeesDueDays { get; set; }

        public string SessionName { get; set; }
        public string LanguageName { get; set; }
        public string TimezoneName { get; set; }
        public string CurrencyName { get; set; }
    }
}