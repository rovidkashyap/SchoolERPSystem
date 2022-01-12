using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Models.DependencyViewModels.SettingViewModel
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public bool isActive { get; set; }
    }
}