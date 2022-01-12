using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Income
{
    public class Income : AuditableEntity<int>
    {
        public int IncomeTypeId { get; set; }
        public virtual IncomeType IncomeTypeName { get; set; }

        public string Name { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Document { get; set; }
        public string Description { get; set; }
    }
}
