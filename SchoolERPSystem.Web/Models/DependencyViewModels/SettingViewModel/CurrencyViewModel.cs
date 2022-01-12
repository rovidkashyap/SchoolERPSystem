using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Models.DependencyViewModels.SettingViewModel
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public bool IsActive { get; set; }
    }
}