using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Expense
{
    public class Expense : AuditableEntity<int>
    {
        public int ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseTypeName { get; set; }

        public string Name { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Document { get; set; }
        public string Description { get; set; }
    }
}
