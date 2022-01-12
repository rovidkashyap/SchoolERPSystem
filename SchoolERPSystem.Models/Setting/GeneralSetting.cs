using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.Dependencies.SettingDependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Setting
{
    public class GeneralSetting : AuditableEntity<int>
    {
        public string SchoolName { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolAddress { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string SchoolEmail { get; set; }
        public int? SessionId { get; set; }
        public string SessionStartMonth { get; set; }
        public int? LanguageId { get; set; }
        public int? TimezoneId { get; set; }
        public int? CurrencyId { get; set; }
        public string CurrencySymbol { get; set; }
        public int? FeesDueDays { get; set; }

        public virtual Session SessionName { get; set; }
        public virtual Language LanguageName { get; set; }
        public virtual Timezone TimezoneName { get; set; }
        public virtual Currency CurrencyName { get; set; }
    }
}
