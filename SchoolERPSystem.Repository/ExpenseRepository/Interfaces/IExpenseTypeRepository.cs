using SchoolERPSystem.Models.Expense;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.ExpenseRepository.Interfaces
{
    public interface IExpenseTypeRepository : IGenericRepository<ExpenseType>
    {
        ExpenseType GetById(int id);
    }
}
