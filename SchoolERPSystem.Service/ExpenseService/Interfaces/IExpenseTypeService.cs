using SchoolERPSystem.Models.Expense;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.ExpenseService.Interfaces
{
    public interface IExpenseTypeService : IEntityService<ExpenseType>
    {
        ExpenseType GetById(int id);
    }
}
