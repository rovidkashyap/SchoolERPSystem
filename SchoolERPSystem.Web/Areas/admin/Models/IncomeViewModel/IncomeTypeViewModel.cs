using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.IncomeViewModel
{
    public class IncomeTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Income Head")]
        public string IncomeHead { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}