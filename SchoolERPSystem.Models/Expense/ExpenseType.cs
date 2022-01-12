using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Expense
{
    public class ExpenseType : AuditableEntity<int>
    {
        public string ExpenseHead { get; set; }
        public string Description { get; set; }
    }
}
