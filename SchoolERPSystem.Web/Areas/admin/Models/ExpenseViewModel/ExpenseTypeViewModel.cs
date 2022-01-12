using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.ExpenseViewModel
{
    public class ExpenseTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Expense Head")]
        public string ExpenseHead { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}