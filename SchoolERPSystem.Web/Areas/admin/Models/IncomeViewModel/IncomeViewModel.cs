using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.IncomeViewModel
{
    public class IncomeViewModel
    {
        public IncomeViewModel()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }

        [Display(Name = "Income Head")]
        public int IncomeTypeId { get; set; }
        public string IncomeTypeName { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Document")]
        public string Document { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}